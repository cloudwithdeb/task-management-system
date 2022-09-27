using DbContextNamespace;
using IRemainderRepositoryNamespace;
using RemainderModelsNamespace;
using TaskDtoNamespace;

namespace RemainderRepositoryNamespace;

public class RemainderRepository : IRemainderRepository
{
     private readonly DbContextEfCore _dbcontext;
    public RemainderRepository(DbContextEfCore dbcontext)
    {
        _dbcontext=dbcontext;
    }
    
    public string? addRemainder(RemainderDto remainder)
    {
          RemainderModel _users_remainder = new RemainderModel
        {
            Description=remainder.Description,
            task=Convert.ToInt32(remainder.task),
            StartDate=remainder.StartDate,
            EndDate=remainder.EndDate,
            IsActivatedDate=DateTime.UtcNow
        };

        _dbcontext.RemainderModel.Add(_users_remainder);
        _dbcontext.SaveChanges();

        return "success";
    }

    public string? deleteRemainder(int Remainderid)
    {
        var dataList = _dbcontext.RemainderModel.Where(t => t.RemainderID.Equals(Remainderid)).FirstOrDefault();
        if(dataList != null)
        {
            _dbcontext.RemainderModel.Remove(dataList);
            _dbcontext.SaveChanges();
            return "success";
        }
        else
        {
            return "remainder does not exists";
        }
    }

    public List<RemainderResponseDto>? getRemainderByUserId(int userid)
    {
        List<RemainderResponseDto> _users_remainder = new List<RemainderResponseDto>();

        var dbTask = _dbcontext.TaskModel.Where(t => t.user.Equals(userid)).ToList();
        foreach(var tsk in dbTask)
        {
            var dbRemainder = _dbcontext.RemainderModel.Where(r => r.task.Equals(tsk.TaskId)).ToList();
            foreach(var rmd in dbRemainder)
            {
                _users_remainder.Add(
                new()
                {
                    Id=rmd.RemainderID,
                    Description=rmd.Description,
                    StartDate=rmd.StartDate,
                    EndDate=rmd.EndDate,
                    taskName=tsk.Name,
                    taskDescription=tsk.Description
                });
            }
        }
        return _users_remainder;
    }

    public string? updateRemainder(int Remainderid, RemainderUpdateDto Remainder)
    {
         List<RemainderResponseDto> _users_remainder = new List<RemainderResponseDto>();
        var dbRemainder = _dbcontext.RemainderModel.Where(r => r.RemainderID.Equals(Remainderid)).FirstOrDefault();
        if(dbRemainder != null)
        {
            if(Remainder.Description != null)
            {
                dbRemainder.Description = Remainder.Description;
            }
            if(Remainder.StartDate != null)
            {
                dbRemainder.StartDate = Remainder.StartDate;
            }
            if(Remainder.EndDate != null)
            {
                dbRemainder.EndDate = Remainder.EndDate;
            }

            _dbcontext.SaveChanges();
            return "success";
        }
        else
        {
            return "remainder does not exists";
        }
        
    }
}

