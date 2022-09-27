using System.ComponentModel.DataAnnotations;

namespace TaskDtoNamespace;

public class TaskDto
{

    public string? Name{
        get;
        set;
    }

    public string? Description{
        get;
        set;
    }
}

public class ResponseTaskDto
{

    public int Id{
        get;
        set;
    }

    public string? Name{
        get;
        set;
    }

    public string? Description{
        get;
        set;
    }
}