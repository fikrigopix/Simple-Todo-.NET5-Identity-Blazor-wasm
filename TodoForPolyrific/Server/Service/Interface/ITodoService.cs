using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoForPolyrific.Server.Models;
using TodoForPolyrific.Shared;

namespace TodoForPolyrific.Server.Service.Interface
{
    public interface ITodoService
    {
        List<TodoViewModel> GetTodos(string userId);
        Todo FindById(int id);
        TodoViewModel Add(TodoViewModel todoViewModel, string userId);
        TodoViewModel Update(TodoViewModel todoViewModel, string userId);
        void Delete(int todoId);
        void DeleteAllByUserId(string userId);
    }
}
