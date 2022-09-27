using LoginDtoNamespace;
using SignupDtoNamespace;

namespace ILoginSignupRepositoryNP;
public interface ILoginSignupRepository
{
    public string? Add(SignupDto signup);
    public List<SignupDto> GetUserByEmail(string email);
}