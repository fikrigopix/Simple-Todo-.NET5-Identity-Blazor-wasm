using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoForPolyrific.Server.Models;
using TodoForPolyrific.Server.Repository.Interface;
using TodoForPolyrific.Server.Service.Interface;
using TodoForPolyrific.Shared;

namespace TodoForPolyrific.Server.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<TodoViewModel> GetTodos(string userId)
        {
            return _todoRepository.GetTodos(userId)
                    .Select(x => new TodoViewModel {
                        Id = x.Id,
                        Title = x.Title,
                        Detail = x.Detail,
                        Status = x.Status,
                        LastModified = x.LastModified
                    }).ToList();
        }

        public Todo FindById(int id)
        {
            return _todoRepository.FindById(id);
        }

        public TodoViewModel Add(TodoViewModel todoViewModel, string userId)
        {
            var todo = new Todo {
                Title = todoViewModel.Title,
                Detail = todoViewModel.Detail,
                Status = todoViewModel.Status,
                LastModified = todoViewModel.LastModified,
                UserId = userId
            };
            var result = _todoRepository.Add(todo);
            return new TodoViewModel
            {
                Id = result.Id,
                Title = result.Title,
                Detail = result.Detail,
                Status = result.Status,
                LastModified = result.LastModified
            };
        }

        public TodoViewModel Update(TodoViewModel todoViewModel, string userId)
        {
            var todo = new Todo
            {
                Id = todoViewModel.Id,
                Title = todoViewModel.Title,
                Detail = todoViewModel.Detail,
                Status = todoViewModel.Status,
                LastModified = todoViewModel.LastModified,
                UserId = userId
            };
            var result = _todoRepository.Update(todo);
            return new TodoViewModel
            {
                Id = result.Id,
                Title = result.Title,
                Detail = result.Detail,
                Status = result.Status,
                LastModified = result.LastModified
            };
        }

        public void Delete (int todoId)
        {
            var todo = _todoRepository.FindById(todoId);
            _todoRepository.Delete(todo);
        }

        public void DeleteAllByUserId (string userId)
        {
            _todoRepository.DeleteAllByUserId(userId);
        }
    }
}
