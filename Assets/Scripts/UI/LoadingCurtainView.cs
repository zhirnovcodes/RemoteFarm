using UnityEngine;

public class LoadingCurtainView : MonoBehaviour
{
    [SerializeField] private GameObject Content;

    public void Enable()
    {
        Content.SetActive(true);
    }

    public void Disable()
    {
        Content.SetActive(false);
    }
}
