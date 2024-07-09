using Cysharp.Threading.Tasks;

public class MockAuthorizationService : IAuthorizationService
{
    private readonly bool IsLogInSuccess;
    private readonly bool IsLogOutSuccess;

    public MockAuthorizationService(bool isLogInSuccess = true, bool isLogOutSuccess = true)
    {
        IsLogInSuccess = isLogInSuccess;
        IsLogOutSuccess = isLogOutSuccess;
    }

    public bool IsLoggedIn { get; private set; }

    public async UniTask<IAuthorizationService.LogInResult> LogIn(string username, string password)
    {
        if (IsLogInSuccess)
        {
            return new IAuthorizationService.LogInResult { Success = true };
        }

        return new IAuthorizationService.LogInResult { Success = false, ErrorMessage = "Mock error" };
    }

    public async UniTask<IAuthorizationService.LogOutResult> LogOut()
    {
        if (IsLogOutSuccess)
        {
            return new IAuthorizationService.LogOutResult { Success = true };
        }

        return new IAuthorizationService.LogOutResult { Success = false, ErrorMessage = "Mock error" };
    }
}
