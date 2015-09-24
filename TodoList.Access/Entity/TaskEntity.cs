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

        public bool actionCreate(Task task)
        {
            var conn = new MySqlConnection(TaskDAO.StringConnection);

            try
            {
                conn.Open();

                var sql = "INSERT INTO tasks (title, description, created_at, user_id) VALUES (@title, @description, @created_at, @user_id)";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@description", task.Description);
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                cmd.Parameters.AddWithValue("@user_id", task.User.Id);

                cmd.ExecuteNonQuery();

                return true;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
