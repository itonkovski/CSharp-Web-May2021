using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext dbContext;

        public TodoItemsController(TodoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            this.dbContext.TodoItems.Add(todoItem);
            await this.dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, ItemToDTO(todoItem));
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await dbContext
                .TodoItems
                .FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(todoItem);
        }
    

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<TodoItemDTO>> GetTodoItems()
        {            
            return await this.dbContext
                .TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await this.dbContext
                .TodoItems
                .FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            this.dbContext.TodoItems.Remove(todoItem);
            await this.dbContext.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            todoItemDTO.Id = id;
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await this.dbContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();

            //Solution without DTO
            //todoItem.Id = id;

            //if (id != todoItem.Id)
            //{
            //    return BadRequest();
            //}

            //this.dbContext.Entry(todoItem).State = EntityState.Modified;

            //try
            //{
            //    await dbContext.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    return NotFound();
            //}

            //return NoContent();
        }

        private bool TodoItemExists(long id) =>
            this.dbContext.TodoItems.Any(x => x.Id == id);

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
