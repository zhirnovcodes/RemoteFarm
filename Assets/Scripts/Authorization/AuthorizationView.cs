using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationView : MonoBehaviour, IAuthorizationView
{
    public event Action OkClicked = () => { };

    [SerializeField] private GameObject Content;
    [SerializeField] private TMP_InputField UserNameText;
    [SerializeField] private TMP_InputField PasswordText;
    [SerializeField] private TMP_Text ErrorText;
    [SerializeField] private TMP_Text StatusText;
    [SerializeField] private Button OkButton;

    public string UserName => UserNameText.text;

    public string Password => PasswordText.text;


    public void Disable()
    {
        Content.SetActive(false);
        OkButton.onClick.RemoveListener(HandleOkClicked);
    }

    public void DisableErrorMessage()
    {
        ErrorText.gameObject.SetActive(false);
    }

    public void Enable()
    {
        Content.SetActive(true);
        OkButton.onClick.AddListener(HandleOkClicked);
    }

    private void HandleOkClicked()
    {
        OkClicked();
    }

    public void EnableErrorMessage(string message)
    {
        ErrorText.gameObject.SetActive(true);
        ErrorText.text = message;
    }

    public void SetStatusText(string text)
    {
        StatusText.text = text;
    }

    public void SetStatusTextColor(Color color)
    {
        StatusText.color = color;
    }
}
