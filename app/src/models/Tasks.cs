using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RemainderModelsNamespace;
using UsersNamespace;
namespace TaskModelNamespace;

[Table("Task")]
public class TaskModel
{
    [Column("Id")]
    [Key, Required]
    public int TaskId{
        get;
        set;
    }

    [Required]
    [Column("name")]
    public string? Name{
        get;
        set;
    }

    [Required]
    [MinLength(10)]
    [Column("description")]
    public string? Description{
        get;
        set;
    }

    [Required]
    [Column("dateCreated")]
    public DateTime DT{
        get;
        set;
    }

    [Required]
    [ForeignKey("UsersModel")]
    public int user{
        get;
        set;
    }

    // Navigation Properties
    public virtual UsersModel? UsersModel{
        get;
        set;
    }

    public virtual ICollection<RemainderModel>? RemainderModel{
        get;
        set;
    }
}

