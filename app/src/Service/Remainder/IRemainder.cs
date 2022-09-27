using RemainderModelsNamespace;

namespace IRemainderServiceNamespace;

public interface IRemainderService
{
    public string? addRemainder(RemainderDto remainder);
    public string? deleteRemainder(int emid);
    public string? updateRemainder(int remid, RemainderUpdateDto remainder);
    public List<RemainderResponseDto>? getRemainderByUserIdAndTaskId(int userid);
}