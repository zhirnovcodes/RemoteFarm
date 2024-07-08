using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class SceneBootstrapper : MonoBehaviour
{
    void Start()
    {
        _ = StartAsync();
    }

    private async UniTask StartAsync()
    {
        await LoadVideoLinks();

        EnableBackground();

        EnableHUD();

        HideLoadingCurtain();

        SetHUDLoading();

        var loadDatabaseTask = LoadDatabaseData();

        var loadSceneDataTask = LoadSceneData();

        await (loadDatabaseTask, loadSceneDataTask);

        EnableCameraControl();

        EnableTeleportation();

        SetHUDLoadingFinished();
    }

    private UniTask LoadVideoLinks()
    {
        throw new NotImplementedException();
    }

    private void HideLoadingCurtain()
    {
        throw new NotImplementedException();
    }

    private UniTask LoadDatabaseData()
    {
        throw new NotImplementedException();
    }


    private UniTask LoadSceneData()
    {
        throw new NotImplementedException();
    }

    private void EnableBackground()
    {

    }

    private void SpawnSceneObjects()
    {

    }

    private void EnableTeleportation()
    {

    }

    private void EnableCameraControl()
    {

    }

    private void SetCameraPositon()
    {

    }

    private void EnableHUD()
    {

    }

    private void SetHUDLoading()
    {

    }

    private void SetHUDLoadingFinished()
    {

    }
}
