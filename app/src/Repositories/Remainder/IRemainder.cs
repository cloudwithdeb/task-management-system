using RemainderModelsNamespace;
namespace IRemainderRepositoryNamespace;

public interface IRemainderRepository
{
    public string? addRemainder(RemainderDto remainder);
    public string? deleteRemainder(int Remainderid);
    public string? updateRemainder(int Remainderid, RemainderUpdateDto Remainder);
    public List<RemainderResponseDto>? getRemainderByUserId(int userid);
}