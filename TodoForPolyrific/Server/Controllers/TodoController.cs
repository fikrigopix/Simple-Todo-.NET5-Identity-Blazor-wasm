using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoForPolyrific.Server.Models;
using TodoForPolyrific.Server.Service.Interface;
using TodoForPolyrific.Shared;

namespace TodoForPolyrific.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<TodoViewModel>> GetTodos()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _todoService.GetTodos(userId);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<TodoViewModel> GetTodoById(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var todo = _todoService.FindById(Convert.ToInt32(id));

            if (userId != todo.UserId)
            {
                return BadRequest();
            }

            return new TodoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Detail = todo.Detail,
                Status = todo.Status,
                LastModified = todo.LastModified
            };
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<TodoViewModel> Add(TodoViewModel viewModel) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _todoService.Add(viewModel, userId);
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult<TodoViewModel> Update(TodoViewModel viewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _todoService.Update(viewModel, userId);
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete(int TodoId)
        {
            try
            {
                _todoService.Delete(TodoId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult DeleteAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                _todoService.DeleteAllByUserId(userId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
