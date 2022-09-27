using ITaskRepositoryNamespace;
using ITaskServiceNamespace;
using TaskDtoNamespace;

namespace TaskServiceNamespace;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;
    public TaskService(ITaskRepository repo)
    {
        _repo=repo;
    }

    public string? addTask(TaskDto task, int userid)
    {
        List<ResponseTaskDto> does_user_creating_task_exists = _repo.getTaskByUserId(userid);
        if(does_user_creating_task_exists.Count > 0)
        {
             var response = _repo.addTask(task, userid);
            return response;
        }
        else
        {
            return "user does not exists";
        }
    
    }

    public string? deleteTask(int taskid)
    {
        var response = _repo.deleteTask(taskid);
        return response;
    }

    public List<ResponseTaskDto>? getByUserId(int userid)
    {
        return _repo.getTaskByUserId(userid);
    }

    public string? updateTask(int taskid, TaskDto task)
    {
        var response = _repo.updateTask(taskid, task);
        return response;
    }
}