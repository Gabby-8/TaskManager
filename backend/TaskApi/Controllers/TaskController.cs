using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static List<TaskItem> Tasks = new()
    {
        new TaskItem { Id = 1, Title = "Test Item 1", IsCompleted = false },
        new TaskItem { Id = 2, Title = "Test Item 2", IsCompleted = true }
    };

    // GET
    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(Tasks);
    }

    // POST
    [HttpPost]
    public IActionResult AddTask(TaskItem task)
    {
        task.Id = Tasks.Count + 1;
        Tasks.Add(task);
        return Ok(task);
    }

    // PUT
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskItem updatedTask)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();

        task.Title = updatedTask.Title;
        task.IsCompleted = updatedTask.IsCompleted;

        return Ok(task);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();

        Tasks.Remove(task);
        return NoContent();
    }
}
