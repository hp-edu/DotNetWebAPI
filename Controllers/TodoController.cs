using Microsoft.AspNetCore.Mvc;
using DotNetWebAPI.Models;

namespace DotNetWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private static List<TodoModel> tasks = new List<TodoModel>();

    public TodoController(ILogger<TodoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("task")]
    public async Task<IActionResult> GetTasks()
    {
        return Ok(tasks); //200
    }

    [HttpGet]
    [Route("task/{id}", Name = "GetTaskById")]
    public async Task<IActionResult> GetTasks(Guid id)
    {
        var task = tasks.Where(o => o.Id == id).SingleOrDefault();
        if (task != null)
        {
            return Ok(task); //200
        }
        else
        {
            return NotFound(); //404
        }
    }

    [HttpPost]
    [Route("task")]
    public async Task<IActionResult> CreateTask(TaskModel task)
    {
        TodoModel todo = new TodoModel();
        todo.Id = Guid.NewGuid();
        todo.Task = task.Task;
        todo.IsDone = false;
        tasks.Add(todo);
        return CreatedAtRoute("GetTaskById", new { id = todo.Id }, todo);
    }

    [HttpPut]
    [Route("task/{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, TaskModel taskModel)
    {
        var task = tasks.Where(o => o.Id == id).SingleOrDefault();
        if (task != null)
        {
            task.Task = taskModel.Task;
            return Ok(task); //200
        }
        else
        {
            return NotFound(); //404
        }
    }

    [HttpDelete]
    [Route("task/{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var task = tasks.Where(o => o.Id == id).SingleOrDefault();
        if (task != null)
        {
            tasks.Remove(task);
            return NoContent(); //204
        }
        else
        {
            return NotFound(); //404
        }
    }

}
