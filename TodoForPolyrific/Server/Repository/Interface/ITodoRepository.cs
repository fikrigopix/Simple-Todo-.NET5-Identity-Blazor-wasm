using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoForPolyrific.Server.Models;

namespace TodoForPolyrific.Server.Repository.Interface
{
    public interface ITodoRepository
    {
        List<Todo> GetTodos(string userId);
        Todo Add(Todo todo);
        Todo Update(Todo todo);
        void Delete(Todo todo);
        Todo FindById(int Id);
        void DeleteAllByUserId(string userId);
    }
}
