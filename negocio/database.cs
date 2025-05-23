using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace negocio
{
    public class database
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public database()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=PROMOS_DB; integrated security=true");
            //connection = new SqlConnection(ConfigurationManager.AppSettings["stringConnection"]);
            command = new SqlCommand();
        }

        public void setQuery(string queryCommand)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = queryCommand;
        }

        public void execQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void execNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setParameter(string varName, object value)
        {
            command.Parameters.AddWithValue(varName, value);
        }

        public void closeConnection()
        {
            if (reader != null)
            {
                reader.Close();
            }
            connection.Close();
        }
    }
}