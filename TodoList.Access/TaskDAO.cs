using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Access.Entity;

namespace TodoList.Access
{
    public class TaskDAO
    {
        public const string StringConnection = "Persist Security Info=False;server=localhost;database=todolist;uid=root;pwd=root";

        private static TaskDAO _instance = null;

        private MySqlConnection conn { get; set; }

        public TaskEntity TaskEntity { get; set; }
        public UserEntity UserEntity { get; set; }

        private TaskDAO()
        {
            if (this.Connect())
            {
                this.TaskEntity = new TaskEntity();
                this.UserEntity = new UserEntity();
            }
        }

        private bool Connect()
        {
            try
            {
                this.conn = new MySqlConnection(TaskDAO.StringConnection);
                this.conn.Open();
                this.conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static TaskDAO Entities
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TaskDAO();
                }

                return _instance;
            }
        }
    }
}
