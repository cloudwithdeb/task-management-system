namespace SchedulerNmaespace;
using System.Threading.Tasks;
using DbContextNamespace;
using IMailNamespace;
using Quartz;

public class SchedulerJob : IJob
{
    private readonly IMail _mail;
    private readonly DbContextEfCore _dbcontext;


    public SchedulerJob(DbContextEfCore dbcontext, IMail mail)
    {
        _dbcontext=dbcontext;
        _mail=mail;
    }

    public Task Execute(IJobExecutionContext context)
    {
        
        var dbRemainder = _dbcontext.RemainderModel.Where(
            r => r.StartDate <= DateTime.UtcNow &&
            r.EndDate >= DateTime.UtcNow &&
            r.IsActivatedDate <= DateTime.UtcNow
            ).ToList();
     
        if(dbRemainder.Count > 0)
        {
            foreach(var remind in dbRemainder)
            {
                var task = _dbcontext.TaskModel.Where(t=>t.TaskId==remind.task).ToList();
                if(task.Count > 0)
                {
                    foreach(var tsk in task)
                    {
                        var user_email = _dbcontext.UsersModel.Where(u=>u.UserID==tsk.user).ToList();

                        foreach(var myemail in user_email)
                        {
                            _mail.sendEmail(remind.Description, "sabina remainder",myemail.Email);
                            var _datetime = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 0);
                            remind.IsActivatedDate = DateTime.UtcNow.AddDays(1);
                            _dbcontext.SaveChanges();
                        }
                    }
                   
                }
                
            }
        }
        return Task.CompletedTask;
    }
}