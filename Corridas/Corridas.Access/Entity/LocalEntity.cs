using Corridas.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Access.Entity
{
    public class LocalEntity : EntityBase
    {
        public LocalEntity()
        {
            this.Tabela = "local";
        }

        public List<Local> GetAll()
        {
            try
            {
                var lista = new List<Local>();

                var sql = "select * from " + this.Tabela;

                var dataSet = new DataSet();
                var query = new MySqlDataAdapter(sql, CorridaDAO.StringConexao);
                query.Fill(dataSet);

                foreach (var item in dataSet.Tables[0].AsEnumerable().ToList())
                {
                    var local = new Local()
                    {
                        Id = Convert.ToInt16(item["Id"]),
                        Cidade = item["Cidade"].ToString(),
                        Uf = item["Uf"].ToString()
                    };

                    lista.Add(local);
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
