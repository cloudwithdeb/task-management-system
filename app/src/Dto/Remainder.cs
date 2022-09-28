namespace RemainderModelsNamespace;

public class RemainderDto
{

    public string? Description{
        get; 
        set;
    }

    public int numberOfDays{
        get;
        set;
    }
 
    public int task{
        get; 
        set;
    }
}

public class RemainderUpdateDto
{

    public string? Description{
        get; 
        set;
    }

    public DateTime StartDate{
        get; 
        set;
    }

    public DateTime EndDate 
    {
        get; 
        set;
    }
}


public class RemainderResponseDto
{

    public int Id{
        get;
        set;
    }

    public string? Description{
        get; 
        set;
    }

    public DateTime StartDate{
        get; 
        set;
    }

    public DateTime EndDate 
    {
        get; 
        set;
    }
 
    public string? taskName{
        get; 
        set;
    }
    public string? taskDescription{
        get;
        set;
    }
}