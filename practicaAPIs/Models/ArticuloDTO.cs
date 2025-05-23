﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practicaAPIs.Models
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public decimal Precio { get; set; }

        public ArticuloDTO()
        {
            Imagenes = new List<Imagen>();
            Marca = new Marca();
            Categoria = new Categoria();
        }

    }
}