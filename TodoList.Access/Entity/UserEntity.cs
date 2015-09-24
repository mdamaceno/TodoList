using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Access.Model;

namespace TodoList.Access.Entity
{
    public class UserEntity : EntityBase
    {
        public UserEntity()
        {
            this.Table = "users";
        }

        public List<User> actionIndex()
        {
            try
            {
                var lst = new List<User>();

                var sql = "select * from " + this.Table;

                var dataSet = new DataSet();
                var query = new MySqlDataAdapter(sql, TaskDAO.StringConnection);
                query.Fill(dataSet);

                foreach (var item in dataSet.Tables[0].AsEnumerable().ToList())
                {
                    var user = new User()
                    {
                        Id = Convert.ToInt16(item["Id"]),
                        Name = item["name"].ToString()
                    };

                    lst.Add(user);
                }

                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
