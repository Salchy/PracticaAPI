using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class articuloDatos
    {
        public List<Articulo> getArticles()
        {
            List<Articulo> articulos = new List<Articulo>();
            Database db = new Database();
            try
            {
                db.setQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio FROM Articulos A INNER JOIN Marcas M ON A.IdMarca = M.Id INNER JOIN Categorias C ON A.IdCategoria = C.Id");
                db.execQuery();

                while (db.Reader.Read())
                {
                    Articulo tempArticle = new Articulo();
                    setArticleData(tempArticle, db.Reader);
                    articulos.Add(tempArticle);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.closeConnection();
            }
            return articulos;
        }

        public string generateCode(string marca)
        {
            string inicialMarca = marca.Substring(0, 1).ToUpper();
            int codigoMarca = 1;
            List<int> codigosExistentes = new List<int>();

            Database database = new Database();
            database.setQuery("SELECT Codigo FROM Articulos WHERE Codigo LIKE @codigo");
            database.setParameter("@codigo", inicialMarca + "%");
            database.execQuery();

            while (database.Reader.Read())
            {
                string codigo = (string)database.Reader["Codigo"];
                codigo = codigo.Substring(1);

                codigosExistentes.Add(int.Parse(codigo));
            }

            while (codigosExistentes.Contains(codigoMarca))
            {
                codigoMarca++;
            }

            return inicialMarca + codigoMarca;
        }

        public void setArticleData(Articulo tempArticle, SqlDataReader data)
        {
            imagenesDatos imagenes = new imagenesDatos();

            tempArticle.Id = (int)data["Id"];
            tempArticle.Codigo = (string)data["Codigo"];
            tempArticle.Nombre = (string)data["Nombre"];
            tempArticle.Descripcion = (string)data["Descripcion"];
            tempArticle.Marca.Nombre = (string)data["Marca"];
            tempArticle.Categoria.Nombre = (string)data["Categoria"];
            tempArticle.Precio = Math.Round((decimal)data["Precio"], 2);
            tempArticle.Imagenes = imagenes.Listar((int)data["Id"]);
        }

        public Articulo getArticle(int id)
        {
            Articulo articulo = new Articulo();

            Database db = new Database();

            try
            {
                db.setQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio FROM Articulos A INNER JOIN Marcas M ON A.IdMarca = M.Id INNER JOIN Categorias C ON A.IdCategoria = C.Id WHERE A.Id = @id");
                db.setParameter("id", id);
                db.execQuery();

                if (db.Reader.Read())
                {
                    setArticleData(articulo, db.Reader);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.closeConnection();
            }

            return articulo;
        }
    }
}
