using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Access.Entity
{
    public class EntityBase
    {
        public string Tabela { get; set; }
        public bool Delete(int id)
        {
            var conexao = new MySqlConnection(CorridaDAO.StringConexao);

            try
            {
                conexao.Open();

                var sql = "delete from " + this.Tabela + " where id = @id";

                var cmd = new MySqlCommand(sql, conexao);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
