using IMailNamespace;
using IRemainderRepositoryNamespace;
using IRemainderServiceNamespace;
using RemainderModelsNamespace;

namespace RemainderServiceNamespace;

public class RemainderService : IRemainderService
{
    private readonly IRemainderRepository _repo;
    private readonly IMail _mail;
    
    public RemainderService(IRemainderRepository repo, IMail mail)
    {
        _repo=repo;
        _mail=mail;
    }
    
    public string? addRemainder(RemainderDto remainder)
    {
        var response = _repo.addRemainder(remainder);
        return response;
    }

    public string? deleteRemainder(int remid)
    {
        var response = _repo.deleteRemainder(remid);
        return response;
    }

    public List<RemainderResponseDto>? getRemainderByUserIdAndTaskId(int userid)
    {
        var _get_all_remainder = _repo.getRemainderByUserId(userid);
        return _get_all_remainder;
    }

    public string? updateRemainder(int remid, RemainderUpdateDto remainder)
    {
        var _update_remainder= _repo.updateRemainder(remid, remainder);
        return _update_remainder;
    }
}



