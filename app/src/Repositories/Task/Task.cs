using DbContextNamespace;
using ITaskRepositoryNamespace;
using TaskDtoNamespace;
using TaskModelNamespace;

namespace TaskRepositoryNamespace;

public class TaskRepository : ITaskRepository
{
    private readonly DbContextEfCore _dbcontext;
    public TaskRepository(DbContextEfCore dbcontext)
    {
        _dbcontext=dbcontext;
    }

    public string? addTask(TaskDto task, int userid)
    {
        TaskModel _users_task = new TaskModel
        {
            Name=task.Name,
            Description=task.Description,
            DT=DateTime.UtcNow,
            user=userid
        };

        _dbcontext.TaskModel.Add(_users_task);
        _dbcontext.SaveChanges();

        return "success";
    }

    public string? deleteTask(int taskid)
    {
        var dataList = _dbcontext.TaskModel.Where(t => t.TaskId.Equals(taskid)).FirstOrDefault();
        if(dataList != null)
        {
            _dbcontext.TaskModel.Remove(dataList);
            _dbcontext.SaveChanges();
            return "success";
        }
        else
        {
            return "task does not exists";
        }
    }

    public List<ResponseTaskDto>? getTaskByUserId(int userid)
    {
        List<ResponseTaskDto> response = new List<ResponseTaskDto>();
        var dataList = _dbcontext.TaskModel.Where(t => t.user.Equals(userid)).ToList();
        foreach(var tsk in dataList)
        {
            response.Add(new() {Id=tsk.TaskId, Name=tsk.Name, Description=tsk.Description});
        }
        return response;
    }

    public string? updateTask(int taskid, TaskDto task)
    {
        var dataList = _dbcontext.TaskModel.Where(t => t.TaskId.Equals(taskid)).FirstOrDefault();
        if(dataList != null)
        {
            if(task.Name != null)
            {
                dataList.Name = task.Name;
            }
            if(task.Description != null) 
            {
                dataList.Description = task.Description;
            }
            _dbcontext.SaveChanges();
            return "success";
        }
        else
        {
            return "task does not exists";
        }
    }
}