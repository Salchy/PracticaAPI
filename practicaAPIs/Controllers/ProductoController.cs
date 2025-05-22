using Antlr.Runtime.Misc;
using practicaAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace practicaAPIs.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        public IEnumerable<Producto> Get()
        {
            return new Producto[] {
                new Producto {
                        Id = 1,
                        Nombre = "Manteca",
                        Precio = 2000.5f,
                        Stock = 8
                },
                new Producto {
                        Id = 2,
                        Nombre = "Leche",
                        Precio = 1500.5f,
                        Stock = 3
                },
            };
        }

        // GET: api/Producto/5
        public Producto Get(int id)
        {
            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto { Id = 1, Nombre = "Manteca", Precio = 200.5f, Stock = 5 });
            productos.Add(new Producto { Id = 2, Nombre = "Leche", Precio = 1500.5f, Stock = 12 });
            productos.Add(new Producto { Id = 3, Nombre = "Don Satur", Precio = 1500.5f, Stock = 3 });
            productos.Add(new Producto { Id = 4, Nombre = "Alfajor", Precio = 150.5f, Stock = 30 });

            Producto filtrar = productos.Find(x => x.Id == id);

            return filtrar;
        }
            

        // POST: api/Producto
        // Podría servir para insertar
        public void Post([FromBody] Producto prd)
        {

        }

        // PUT: api/Producto/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Producto/5
        public void Delete(int id)
        {
        }
    }
}
