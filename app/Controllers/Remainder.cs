using IRemainderServiceNamespace;
using Microsoft.AspNetCore.Mvc;
using RemainderModelsNamespace;
using ResponseModelNamespace;

namespace RemainderNamespace;

[ApiController]
[Route("[controller]")]
public class Remainder : ControllerBase
{
    private readonly IRemainderService _svc;
    private readonly ILogger<Remainder> _logger;
    public Remainder(IRemainderService svc, ILogger<Remainder> logger)
    {
          _svc=svc;
          _logger=logger;
    }

    [HttpPost]
    public IActionResult AddRemainder([FromBody]RemainderDto remainder)
    {
          try
          {
               var _add_remainder = _svc.addRemainder(remainder);
               return Ok(new ResponseModel{message=_add_remainder});
          }
          catch(Exception e)
          {
               _logger.LogWarning(e.Message);
               return Ok(new ResponseModel{message="error"});
          }
    }

   [HttpGet]
   public IActionResult GetAllRemainder([FromHeader]string userid)
   {
        var remainders = _svc.getRemainderByUserIdAndTaskId(Convert.ToInt32(userid));
        return Ok(remainders);
   } 

   [HttpPut]
   public IActionResult UpdateRemainder([FromBody]RemainderUpdateDto remainder, [FromHeader] string remainderid)
   {
       try
       {
           var _add_remainder = _svc.updateRemainder(Convert.ToInt32(remainderid), remainder);
           return Ok(new ResponseModel{message=_add_remainder});
       }
       catch(Exception e)
       {
          _logger.LogWarning(e.Message);
          return Ok(new ResponseModel{message="error"});
       }
   }

   [HttpDelete]
   public IActionResult DeleteRemainder([FromHeader]string remainderid)
   {
          try
          {
               var delete_remainder = _svc.deleteRemainder(Convert.ToInt32(remainderid));  
               return Ok(new ResponseModel{message=delete_remainder});
          }
          catch(Exception e)
          {
               _logger.LogWarning(e.Message);
               return Ok(new ResponseModel{message="error"});
          }
   }
}