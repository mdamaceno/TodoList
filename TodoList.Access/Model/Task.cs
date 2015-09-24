using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Access.Model
{
    public class Task
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
    }
}
