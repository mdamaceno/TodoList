using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Access.Entity
{
    public class EntityBase
    {
        public string Table { get; set; }
        public bool Delete(int id)
        {
            var connection = new MySqlConnection(TaskDAO.StringConnection);

            try
            {
                connection.Open();

                var sql = "delete from " + this.Table + " where id = @id";
                var cmd = new MySqlCommand(sql, connection);

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
                connection.Close();
            }
        }
    }
}
