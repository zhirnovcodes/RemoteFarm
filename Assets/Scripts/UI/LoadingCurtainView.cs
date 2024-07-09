using UnityEngine;

public class LoadingCurtainView : MonoBehaviour
{
    [SerializeField] private GameObject Content;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Enable()
    {
        Content.SetActive(true);
    }

    public void Disable()
    {
        Content.SetActive(false);
    }
}
