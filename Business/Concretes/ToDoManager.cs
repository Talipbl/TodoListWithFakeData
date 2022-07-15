using Business.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;

        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }

        public async Task<List<ToDo>> GetToDos()
        {
            var result = await _toDoDal.GetToDos();
            return result;
        }

        public async Task<List<ToDoListWithJoin>> GetToDosWithJoin()
        {
            var result = await _toDoDal.GetToDosWithJoin();
            return result;
        }
    }
}
