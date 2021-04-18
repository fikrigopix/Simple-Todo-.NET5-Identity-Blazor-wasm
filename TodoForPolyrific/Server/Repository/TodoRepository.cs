using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoForPolyrific.Server.Data;
using TodoForPolyrific.Server.Models;
using TodoForPolyrific.Server.Repository.Interface;

namespace TodoForPolyrific.Server.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Todo Add(Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public List<Todo> GetTodos(string userId)
        {
            return _context.Todo.Where(x => x.UserId == userId).ToList();
        }

        public Todo Update(Todo todo)
        {
            _context.Todo.Update(todo);
            _context.SaveChanges();
            return todo;
        }

        public void Delete(Todo todo)
        {
            _context.Todo.Remove(todo);
            _context.SaveChanges();
        }

        public Todo FindById(int Id)
        {
            return _context.Todo.Find(Id);
        }

        public void DeleteAllByUserId(string userId)
        {
            var todos = GetTodos(userId);
            _context.Todo.RemoveRange(todos);
            _context.SaveChanges();
        }
    }
}
