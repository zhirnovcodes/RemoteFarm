using System;
using UnityEngine;

public interface IAuthorizationView
{
    event Action OkClicked;

    public string UserName { get; }
    public string Password { get; }

    public void Enable();
    public void Disable();
    public void SetStatusText(string text);
    public void SetStatusTextColor(Color color);
    public void EnableErrorMessage(string message);
    public void DisableErrorMessage();
}