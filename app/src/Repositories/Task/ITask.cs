using TaskDtoNamespace;

namespace ITaskRepositoryNamespace;

public interface ITaskRepository
{
    public string? addTask(TaskDto task, int userid);
    public string? deleteTask(int taskid);
    public string? updateTask(int taskid, TaskDto task);
    public List<ResponseTaskDto>? getTaskByUserId(int userid);
}