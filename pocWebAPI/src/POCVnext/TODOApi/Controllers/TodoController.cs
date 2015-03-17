﻿using Microsoft.AspNet.Mvc;
using POCVnext.TODOApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace POCVnext.TODOApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : BaseController
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.AllItems;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public void CreateTodoItem([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _repository.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (_repository.TryDelete(id))
            {
                return new HttpStatusCodeResult(204); // 201 No Content
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}