using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IToDoService
    {
        Task<List<ToDo>> GetToDos();
        Task<List<ToDoListWithJoin>> GetToDosWithJoin();
    }
}
