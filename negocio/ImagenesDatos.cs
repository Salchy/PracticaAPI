using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class imagenesDatos
    {
        public List<Imagen> Listar(int id)
        {
            List<Imagen> lista = new List<Imagen>();

            Database db = new Database();

            try
            {
                db.setQuery("SELECT ImagenUrl FROM Imagenes WHERE IdArticulo = @id");
                db.setParameter("@id", id);
                db.execQuery();

                while (db.Reader.Read())
                {
                    lista.Add(new Imagen((string)db.Reader["ImagenUrl"]));
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
            return lista;
        }
    }
}
