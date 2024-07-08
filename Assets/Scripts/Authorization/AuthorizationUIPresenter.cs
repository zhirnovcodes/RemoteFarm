using System;
using UnityEngine;

public class AuthorizationUIPresenter
{
    private readonly IAuthorizationUIView View;

    public event Action OkClicked = () => { };

    public AuthorizationUIPresenter(IAuthorizationUIView view)
    {
        View = view;
    }

    public string Password { get; }
    public string UserName { get; }

    public void Enable()
    {
        View.Enable();

        View.OkClicked += HandleOkClicked;
    }

    public void Disable()
    {
        View.Disable();

        View.OkClicked -= HandleOkClicked;
    }

    private void HandleOkClicked()
    {
        OkClicked();
    }

    public void SetStatus(Status status)
    {
        const string SuccessText = "Authorization Succeded!";
        const string FailText = "Authorization failed";
        const string LoadingText = "Please wait...";

        switch (status)
        {
            case Status.Success:
                View.SetStatusText(SuccessText);
                View.SetStatusTextColor(Color.green);
                View.DisableErrorMessage();
                break;
            case Status.Waiting:
                View.SetStatusText(LoadingText);
                View.SetStatusTextColor(Color.yellow);
                View.DisableErrorMessage();
                break;
            case Status.Fail:
                View.SetStatusText(FailText);
                View.SetStatusTextColor(Color.red);
                break;
        }
    }

    public void SetErrorString(string error)
    {
        View.EnableErrorMessage(error);
    }

    public enum Status
    {
        Success,
        Fail,
        Waiting
    }
}
