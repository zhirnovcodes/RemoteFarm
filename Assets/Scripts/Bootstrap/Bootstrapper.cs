using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    private ISceneLoader SceneLoader;
    private IAuthorizationService AuthorizationService;
    private AuthorizationUIPresenter AuthorizationUI;
    private LoadingCurtainView LoadingCurtainView;

    [Inject]
    public void Initialize(
        IAuthorizationService authorizationService,
        AuthorizationUIPresenter authorizationUI,
        LoadingCurtainView loadingCurtainView,
        ISceneLoader sceneLoader)
    {
        AuthorizationService = authorizationService;
        AuthorizationUI = authorizationUI;
        LoadingCurtainView = loadingCurtainView;
        SceneLoader = sceneLoader;
    }

    public void Start()
    {
        Log("Start");

        DontDestroyOnLoad(this);

        _ = StartAsync();
    }

    private async UniTask StartAsync()
    {
        Log("StartAsync");

        ShowAuthorizationUI();

        await Authorize();

        ShowLoadingCurtain();

        HideAuthorizationUI();

        await LoadFarmScene();
    }

    private void ShowLoadingCurtain()
    {
        LoadingCurtainView.Enable();
    }

    private void HideAuthorizationUI()
    {
        AuthorizationUI.Disable();
    }

    private void ShowAuthorizationUI()
    {
        AuthorizationUI.Enable();
    }

    private async UniTask Authorize()
    {
        const string EmptyNameErrorMessage = "Empty username";
        const string EmptyPasswordErrorMessage = "Empty password";

        while (true)
        {
            await WaitOkButtonClicked();

            var userName = AuthorizationUI.UserName;
            var password = AuthorizationUI.Password;

            if (string.IsNullOrEmpty(userName))
            {
                AuthorizationUI.SetStatus(AuthorizationUIPresenter.Status.Fail);
                AuthorizationUI.SetErrorString(EmptyNameErrorMessage);
                continue;
            }

            if (string.IsNullOrEmpty(password))
            {
                AuthorizationUI.SetStatus(AuthorizationUIPresenter.Status.Fail);
                AuthorizationUI.SetErrorString(EmptyPasswordErrorMessage);
                continue;
            }

            AuthorizationUI.SetStatus(AuthorizationUIPresenter.Status.Waiting);

            var result = await AuthorizationService.LogIn(userName, password);

            if (result.Success)
            {
                AuthorizationUI.SetStatus(AuthorizationUIPresenter.Status.Success);
                return;
            }
            else
            {
                AuthorizationUI.SetStatus(AuthorizationUIPresenter.Status.Fail);
                AuthorizationUI.SetErrorString(result.ErrorMessage);
            }
        }

        async UniTask WaitOkButtonClicked()
        {
            var token = new CancellationTokenSource();

            AuthorizationUI.OkClicked += HandleOkClicked;

            await UniTask.WaitUntilCanceled(token.Token);

            void HandleOkClicked()
            {
                AuthorizationUI.OkClicked -= HandleOkClicked;
                token.Cancel();
            }
        }
    }


    private async UniTask LoadFarmScene()
    {
        await SceneLoader.LoadFarm();
    }

    private void Log(string message)
    {
        Debug.Log($"{nameof(Bootstrapper)} - {message}");
    }

}
