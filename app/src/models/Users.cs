using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskModelNamespace;

namespace UsersNamespace;

[Table("Users")]
public class UsersModel
{
    [Column("Id")]
    [Key, Required]
    public int UserID{
        get;
        set;
    }

    [Required]
    [MinLength(1)]
    [Column("firstName")]
    public string? Firstname{
        get;
        set;
    }

    [Required]
    [MinLength(1)]
    [Column("lastName")]
    public string? Lastname{
        get;
        set;
    }

    [Required]
    [MinLength(2)]
    [Column("email")]
    public string? Email{
        get;
        set;
    }

    [Required]
    [MinLength(5)]
    [Column("password")]
    public string? Password{
        get;
        set;
    }

    // Navigation Property
    public virtual ICollection<TaskModel>? TaskModel{
        get;
        set;
    }

}
