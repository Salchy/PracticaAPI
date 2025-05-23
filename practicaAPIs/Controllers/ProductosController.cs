using Antlr.Runtime.Misc;
using dominio;
using negocio;
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
        public IEnumerable<Articulo> Get()
        {
            articuloDatos articulos = new articuloDatos();
            return articulos.getArticles();
        }

        // GET: api/Producto/5
        public Articulo Get(int id)
        {
            articuloDatos articulos = new articuloDatos();
            Articulo articulo = articulos.getArticle(id);
            return articulo;
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
