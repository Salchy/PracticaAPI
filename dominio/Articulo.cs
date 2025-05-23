using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public decimal Precio { get; set; }

        public Articulo()
        {
            Imagenes = new List<Imagen>();
            Marca = new Marca();
            Categoria = new Categoria();
        }

        public Articulo(string nombre, string descripcion, string marca, string categoria, decimal precio)
        {
            
            Imagenes = new List<Imagen>();
            Marca = new Marca(marca);
            Categoria = new Categoria(categoria);
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = Precio;

            //Codigo = generateCode(string marca);
        }

        
    }
}