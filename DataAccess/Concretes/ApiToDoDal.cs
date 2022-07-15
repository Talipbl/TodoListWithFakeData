using DataAccess.Abstracts;
using DataAccess.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ApiToDoDal : IToDoDal
    {
        private List<User> Users { get; set; }
        private List<ToDo> ToDos { get; set; }
        public async Task<ToDo> GetToDoDetail(int toDoId)
        {
            ToDos = await GetApiData<List<ToDo>>("https://jsonplaceholder.typicode.com/todos");
            Users = await GetApiData<List<User>>($"https://jsonplaceholder.typicode.com/users/{toDoId}");
            var result = from td in ToDos
                         join us in Users on td.UserId equals us.Id
                         where td.ID == toDoId
                         select new ToDoListWithJoin
                         {
                             ID = td.ID,
                             UserName = us.Name,
                             EMail = us.EMail,
                             Title = td.Title,
                             Completed = td.Completed
                         };
            return (ToDo)result;
        }
        private static async Task<T> GetApiData<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            T toDos = JsonConvert.DeserializeObject<T>(result);
            return toDos;
        }

        public async Task<List<ToDo>> GetToDos()
        {
            ToDos = await GetApiData<List<ToDo>>("https://jsonplaceholder.typicode.com/todos");
            return ToDos;
        }

        public async Task<List<ToDoListWithJoin>> GetToDosWithJoin()
        {
            ToDos = await GetApiData<List<ToDo>>("https://jsonplaceholder.typicode.com/todos");
            Users = await GetApiData<List<User>>("https://jsonplaceholder.typicode.com/users");
            var result = from td in ToDos
                         join us in Users on td.UserId equals us.Id
                         select new ToDoListWithJoin
                         {
                             ID = td.ID,
                             UserName = us.Name,
                             EMail = us.EMail,
                             Title = td.Title,
                             Completed = td.Completed
                         };
            return result.ToList();
        }
    }
}
