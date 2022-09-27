using Microsoft.EntityFrameworkCore;
using RemainderModelsNamespace;
using TaskModelNamespace;
using UsersNamespace;

namespace DbContextNamespace;

public class DbContextEfCore : DbContext
{
    public DbContextEfCore(DbContextOptions<DbContextEfCore> options) : base(options){}

    // Configure DbSet
    public virtual DbSet<RemainderModel> RemainderModel {get; set;} 
    public virtual DbSet<UsersModel> UsersModel {get; set;}
    public virtual DbSet<TaskModel> TaskModel {get; set;}
}