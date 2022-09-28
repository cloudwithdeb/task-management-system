using DbContextNamespace;
using ILoginSignupRepositoryNP;
using ILoginSignupServiceNSP;
using IMailNamespace;
using IRemainderRepositoryNamespace;
using IRemainderServiceNamespace;
using ITaskRepositoryNamespace;
using ITaskServiceNamespace;
using LoginSignupRepositoryNamespace;
using LoginSignupServiceNS;
using MailNamespace;
using Microsoft.EntityFrameworkCore;
using Quartz;
using RemainderRepositoryNamespace;
using RemainderServiceNamespace;
using SchedulerNmaespace;
using TaskRepositoryNamespace;
using TaskServiceNamespace;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContextEfCore>(e=>e.UseNpgsql(builder.Configuration.GetConnectionString("DB_CON_STR")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Signup And Login Register
builder.Services.AddScoped<ILoginSignupService, LoginSignupService>();
builder.Services.AddScoped<ILoginSignupRepository, LoginSignupRepository>();

// Task Register
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Remainder Register
builder.Services.AddScoped<IRemainderRepository, RemainderRepository>();
builder.Services.AddScoped<IRemainderService, RemainderService>();

// Mail Register
builder.Services.AddScoped<IMail, Mail>();

// Quartz.Net Job register
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    var jobKey = new JobKey("DemoJob");
    q.AddJob<SchedulerJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DemoJob-trigger")
        .WithCronSchedule("0/10 * * * * ?"));

});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
