using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Api.Data;
using Practice.Api.Entities;

namespace Practice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /api/tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        var tasks = await _context.Tasks
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();

        return Ok(tasks);
    }

    // GET: /api/tasks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    // POST: /api/tasks
    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
    {
        task.CreatedAt = DateTime.UtcNow;

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTask),
            new { id = task.Id },
            task
        );
    }

    // PUT: /api/tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
    {
        if (id != updatedTask.Id)
            return BadRequest("El id de la URL no coincide con el del body.");

        var existingTask = await _context.Tasks.FindAsync(id);

        if (existingTask == null)
            return NotFound();

        existingTask.Title = updatedTask.Title;
        existingTask.Description = updatedTask.Description;
        existingTask.DueDate = updatedTask.DueDate;
        existingTask.Status = updatedTask.Status;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: /api/tasks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}