using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TodoList.Access.Model;

namespace TodoList.Access.Entity
{
    public class TaskEntity : EntityBase
    {
        public TaskEntity()
        {
            this.Table = "tasks";
        }

        public List<Task> actionIndex()
        {
            try
            {
                var lst = new List<Task>();

                var sql = "select * from " + this.Table;

                var dataSet = new DataSet();
                var query = new MySqlDataAdapter(sql, TaskDAO.StringConnection);
                query.Fill(dataSet);

                var users = TaskDAO.Entities.UserEntity.actionIndex();

                foreach (var item in dataSet.Tables[0].AsEnumerable().ToList())
                {
                    var task = new Task()
                    {
                        Id = Convert.ToInt16(item["Id"]),
                        Title = item["Title"].ToString(),
                        Description = item["Description"].ToString(),
                        CreatedAt = Convert.ToDateTime(item["Created_At"]),
                        User = users.FirstOrDefault(f => f.Id == Convert.ToInt16(item["User_id"]))
                    };

                    lst.Add(task);
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
