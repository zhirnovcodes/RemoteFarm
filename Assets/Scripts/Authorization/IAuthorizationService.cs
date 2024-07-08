using Cysharp.Threading.Tasks;

public interface IAuthorizationService
{
    UniTask<LogInResult> LogIn(string username, string password);
    UniTask<LogOutResult> LogOut();

    bool IsLoggedIn { get; }

    public class LogInResult
    {
        public bool Success;
        public string ErrorMessage;
    }


    public class LogOutResult
    {
        public bool Success;
        public string ErrorMessage;
    }

}
