using DbContextNamespace;
using ILoginSignupRepositoryNP;
using ILoginSignupServiceNSP;
using LoginDtoNamespace;
using SignupDtoNamespace;

namespace LoginSignupServiceNS;
public class LoginSignupService : ILoginSignupService
{
    private readonly ILoginSignupRepository _repo;
    private readonly ILogger<LoginSignupService> _logger;

    public LoginSignupService(ILoginSignupRepository repo, ILogger<LoginSignupService> logger)
    {
        _repo=repo;
        _logger=logger;
    }

    public string? Login(LoginDto login)
    {
        string users_encrypted_password = "";
        int users_id = 0;

        List<SignupDto> does_email_exists = _repo.GetUserByEmail(login.Email);
        if(does_email_exists.Count > 0)
        {   
            foreach(var user in does_email_exists)
            {
                users_encrypted_password = user.Password;
                users_id = user.Id;
            }
            var isVerifyPassword = BCrypt.Net.BCrypt.Verify(login.Password, users_encrypted_password);
            if(isVerifyPassword)
            {
                return Convert.ToString(users_id);
            }
            else
            {
                return "Invalid username or password";
            }
        }
        else
        {
            return "Invalid username or password";
        }
        
    }

    public string? Signup(SignupDto users)
    {
      
        List<SignupDto> does_email_exists = _repo.GetUserByEmail(users.Email);
        if(does_email_exists.Count > 0)
        {
            return "email has been taken";
        }
        else
        {
             var response = _repo.Add(users);
            return response;
        }
       
    }
}