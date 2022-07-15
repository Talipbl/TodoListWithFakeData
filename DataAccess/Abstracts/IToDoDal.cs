using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IToDoDal
    {
        Task<List<ToDo>> GetToDos();
        Task<ToDo> GetToDoDetail(int toDoId);
        Task<List<ToDoListWithJoin>> GetToDosWithJoin();
    }
}
