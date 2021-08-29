using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oordring.Api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oordring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<TodosController>
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _context.todos.ToList();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {

            Todo todo = _context.todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;

        }

        // POST api/<TodosController>
        [HttpPost]
        public Todo Post([FromBody] Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
          public ActionResult<Todo> Put(int id, [FromBody] Todo todo)
        {
            var mytodo = _context.todos.FirstOrDefault(x => x.Id == id);
            if (mytodo == null)
            {
                return NotFound();
            }
            mytodo.Title = todo.Title;
            mytodo.Completed = todo.Completed;
            _context.SaveChanges();
            return Ok(mytodo);
        }
        

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todo = _context.todos.FirstOrDefault(x => x.Id == id);
            if(todo == null)
            {
                return NotFound();
            }
            _context.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
