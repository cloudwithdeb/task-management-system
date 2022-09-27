using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskModelNamespace;
namespace RemainderModelsNamespace;

[Table("Remainder")]
public class RemainderModel
{
    [Column("Id")]
    [Key, Required]
    public int RemainderID{
        get; 
        set;
    }

    [Required]
    [MinLength(5)]
    [Column("description")]
    public string? Description{
        get; 
        set;
    }

    [Required]
    [Column("isActivatedDate")]
    public DateTime IsActivatedDate{
        get; 
        set;
    }

    [Required]
    [Column("startDate")]
    public DateTime StartDate{
        get; 
        set;
    }

    [Required]
    [Column("endDate")]
    public DateTime EndDate 
    {
        get; 
        set;
    }
    
    [Required]
    [ForeignKey("TaskModel")]
    public int task{
        get; 
        set;
    }

    // Navigation properties
    public TaskModel? TaskModel{
        get;
        set;
    }
}