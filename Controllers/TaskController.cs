using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public TaskController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _db.Tasks.ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] TaskItem newTask)
        {
            _db.Tasks.AddAsync(newTask);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] TaskItem updatedTask)
        {
            if (id != updatedTask.Id)
                return BadRequest("ID mismatch");

            var existing = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (existing == null)
                return NotFound("Task not found");

            existing.Name = updatedTask.Name;
            existing.IsCompleted = updatedTask.IsCompleted;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return NotFound("Task not found");

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
