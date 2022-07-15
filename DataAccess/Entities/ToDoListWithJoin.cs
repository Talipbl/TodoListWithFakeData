using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ToDoListWithJoin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
