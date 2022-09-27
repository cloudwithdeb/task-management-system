using TaskDtoNamespace;

namespace ITaskServiceNamespace;

public interface ITaskService
{
    public string? addTask(TaskDto task, int userid);
    public string? deleteTask(int taskid);
    public string? updateTask(int taskid, TaskDto task);
    public List<ResponseTaskDto>? getByUserId(int userid);
}