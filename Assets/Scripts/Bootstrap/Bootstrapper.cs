using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    // DI
    private ISceneLoader SceneLoader;
    private IAuthorizationService AuthorizationService;
    private ViewsFactory ViewsFactory;

    // Created
    private AuthorizationPresenter AuthorizationPresenter;
    private LoadingCurtainView LoadingCurtainView;

    [Inject]
    public void Initialize(
        IAuthorizationService authorizationService,
        ISceneLoader sceneLoader,
        ViewsFactory viewsFactory)
    {
        AuthorizationService = authorizationService;
        SceneLoader = sceneLoader;
        ViewsFactory = viewsFactory;
    }

    public void Start()
    {
        Log("Start");

        _ = StartAsync();
    }

    private async UniTask StartAsync()
    {
        Log("StartAsync");

        await LoadViews();

        ShowAuthorizationUI();

        await Authorize();

        ShowLoadingCurtain();

        HideAuthorizationUI();

        await LoadFarmScene();
    }

    private async UniTask LoadViews()
    {
        LoadingCurtainView = await ViewsFactory.LoadView<LoadingCurtainView>(Views.LoadingCurtainView);

        var authView = await ViewsFactory.LoadView<AuthorizationView>(Views.AuthorizationView);

        AuthorizationPresenter = new AuthorizationPresenter(authView);
    }

    private void ShowLoadingCurtain()
    {
        Log("ShowLoadingCurtain");

        LoadingCurtainView.Enable();
    }

    private void HideAuthorizationUI()
    {
        Log("HideAuthorizationUI");

        AuthorizationPresenter.Disable();
    }

    private void ShowAuthorizationUI()
    {
        Log("ShowAuthorizationUI");

        AuthorizationPresenter.Enable();
    }

    private async UniTask Authorize()
    {
        const string EmptyNameErrorMessage = "Empty username";
        const string EmptyPasswordErrorMessage = "Empty password";

        Log("Authorize");

        while (true)
        {
            await WaitOkButtonClicked();

            var userName = AuthorizationPresenter.UserName;
            var password = AuthorizationPresenter.Password;

            if (string.IsNullOrEmpty(userName))
            {
                AuthorizationPresenter.SetStatus(AuthorizationPresenter.Status.Fail);
                AuthorizationPresenter.SetErrorString(EmptyNameErrorMessage);
                continue;
            }

            if (string.IsNullOrEmpty(password))
            {
                AuthorizationPresenter.SetStatus(AuthorizationPresenter.Status.Fail);
                AuthorizationPresenter.SetErrorString(EmptyPasswordErrorMessage);
                continue;
            }

            AuthorizationPresenter.SetStatus(AuthorizationPresenter.Status.Waiting);

            var result = await AuthorizationService.LogIn(userName, password);

            if (result.Success)
            {
                AuthorizationPresenter.SetStatus(AuthorizationPresenter.Status.Success);
                return;
            }
            else
            {
                AuthorizationPresenter.SetStatus(AuthorizationPresenter.Status.Fail);
                AuthorizationPresenter.SetErrorString(result.ErrorMessage);
            }
        }

        async UniTask WaitOkButtonClicked()
        {
            var token = new CancellationTokenSource();

            AuthorizationPresenter.OkClicked += HandleOkClicked;

            await UniTask.WaitUntilCanceled(token.Token);

            void HandleOkClicked()
            {
                AuthorizationPresenter.OkClicked -= HandleOkClicked;
                token.Cancel();
            }
        }
    }


    private async UniTask LoadFarmScene()
    {
        Log("LoadFarmScene");

        await SceneLoader.LoadFarm();
    }

    private void Log(string message)
    {
        Debug.Log($"{nameof(Bootstrapper)} - {message}");
    }

}
