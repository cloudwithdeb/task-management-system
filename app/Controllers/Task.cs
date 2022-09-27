using ITaskServiceNamespace;
using Microsoft.AspNetCore.Mvc;
using ResponseModelNamespace;
using TaskDtoNamespace;

namespace TaskNamespace;

[ApiController]
[Route("[controller]")]
public class UsersTask : ControllerBase
{

     private readonly ILogger<UsersTask> _logger;
     private readonly ITaskService _svc;

     public UsersTask(ILogger<UsersTask> logger, ITaskService svc)
     {
          _logger=logger;
          _svc=svc;
     }

    [HttpPost]
    public IActionResult AddTask([FromBody]TaskDto task, [FromHeader] string id)
    {
        try
        {
          var _add_task = _svc.addTask(task, Convert.ToInt32(id));
          return Ok(new ResponseModel{message=_add_task});
        }
        catch(Exception e)
        {
          _logger.LogWarning(e.Message);
          return Ok(new ResponseModel{message="error"});
        }
    }

   [HttpGet]
   public IActionResult GetAllTask([FromHeader] string userid)
   {
        try
        {
          var _get_users_task = _svc.getByUserId(Convert.ToInt32(userid));
          return Ok(_get_users_task);
        }
        catch(Exception e)
        {
          _logger.LogWarning(e.Message);
          return Ok(new ResponseModel{message="error"});
        }
   } 

   [HttpPut]
   public IActionResult UpdateTask([FromHeader] string id, [FromBody] TaskDto task)
   {
          try
          {
               var _update_task = _svc.updateTask(Convert.ToInt32(id), task);
               return Ok(new ResponseModel{message=_update_task});
          }
          catch(Exception e)
          {    
               _logger.LogWarning(e.Message);
               return Ok(new ResponseModel{message="error"});
          }
   }

   [HttpDelete]
   public IActionResult DeleteTask([FromHeader] string id)
   {
        try
        {
          var response = _svc.deleteTask(Convert.ToInt32(id));
          return Ok(new ResponseModel{message=response});
        }
        catch(Exception e)
        {
          _logger.LogWarning(e.Message);
          return Ok(new ResponseModel{message="error"});
        }
   }
}