namespace DotNetWebAPI.Models;

public class TodoModel
{
    public Guid Id { get; set; }
    public string Task { get; set; }
    public bool IsDone { get; set; }
}

public class TaskModel
{
    public string Task { get; set; }

}