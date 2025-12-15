using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private static List<TaskItem> Tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learn React", IsCompleted = false },
        new TaskItem { Id = 2, Title = "Learn C# API", IsCompleted = true }
    };

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(Tasks);
    }

    [HttpPost]
    public IActionResult AddTask(TaskItem task)
    {
        task.Id = Tasks.Count + 1;
        Tasks.Add(task);
        return Ok(task);
    }
}
