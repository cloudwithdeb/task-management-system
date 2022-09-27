using Microsoft.AspNetCore.Mvc;
using ILoginSignupServiceNSP;
using SignupDtoNamespace;
using LoginDtoNamespace;
using ResponseModelNamespace;
namespace SignupLoginNamespace;

[ApiController]
[Route("controller")]
public class SignupLogin : ControllerBase
{

    private readonly ILoginSignupService _svc;
    private readonly ILogger<SignupLogin> _logger;

    public SignupLogin(ILoginSignupService svc, ILogger<SignupLogin> logger)
    {
        _logger=logger;
        _svc=svc;
    }

    [HttpPost("/signup")]
    public ResponseModel Signup(SignupDto users)
    {
        try
        {
            var _signup = _svc.Signup(users);
            return new ResponseModel {message=_signup};

        }
        catch(Exception e)
        {
            _logger.LogWarning(e.Message);
            return new ResponseModel {message="error"};

        }
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginDto login)
    {
        try
        {
            var _login = _svc.Login(login);
            return Ok(new ResponseModel {message=_login});
        }
        catch(Exception e)
        {
            _logger.LogWarning(e.Message);
            return Ok(new ResponseModel {message="error"});
        }
    }
}