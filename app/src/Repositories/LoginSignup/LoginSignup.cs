using ILoginSignupRepositoryNP;
using SignupDtoNamespace;
using DbContextNamespace;
using UsersNamespace;

namespace LoginSignupRepositoryNamespace;
public class LoginSignupRepository : ILoginSignupRepository
{
    private readonly DbContextEfCore _dbcontext;
    public LoginSignupRepository(DbContextEfCore dbContext)
    {
        _dbcontext=dbContext;
    }

    public string? Add(SignupDto signup)
    {

        var encrypted_password = BCrypt.Net.BCrypt.HashPassword(signup.Password);
        UsersModel _users_model = new UsersModel
        {
            Email=signup.Email,
            Firstname=signup.Firstname,
            Lastname=signup.Lastname,
            Password=encrypted_password
        };

        _dbcontext.UsersModel.Add(_users_model);
        _dbcontext.SaveChanges();

        return "success";
    }

    public List<SignupDto> GetUserByEmail(string email)
    {
            
        List<SignupDto> response = new List<SignupDto>();
        var dataList = _dbcontext.UsersModel.Where(u => u.Email.Equals(email)).ToList();
        foreach(var user in dataList)
        {
            response.Add(new() {Email=user.Email, Password=user.Password, Id=user.UserID});
        }
        return response;
    }
}