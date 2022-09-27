namespace ILoginSignupServiceNSP;

using LoginDtoNamespace;
using SignupDtoNamespace;

public interface ILoginSignupService
{
    public string? Signup(SignupDto users);
    public string? Login(LoginDto login);
}
