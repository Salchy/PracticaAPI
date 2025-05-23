using Antlr.Runtime.Misc;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace practicaAPIs.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo
        public IEnumerable<Articulo> Get()
        {
            articuloDatos articulos = new articuloDatos();
            return articulos.getArticles();
        }

        // GET: api/Articulo/5
        public Articulo Get(int id)
        {
            articuloDatos articulos = new articuloDatos();
            Articulo articulo = articulos.getArticle(id);
            return articulo;
        }


        // POST: api/Articulo
        // Podría servir para insertar artículos
        public void Post([FromBody] Articulo art)
        {

        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
