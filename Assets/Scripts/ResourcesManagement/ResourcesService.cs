using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ResourcesService : IResourcesService
{
    public async UniTask<T> Load<T>(string path)
    {
        var request = Resources.LoadAsync(path);
        var resultObject = await request.ToUniTask();
        var resultGameObject = (GameObject)resultObject;
        var clone = GameObject.Instantiate(resultGameObject);

        return clone.GetComponent<T>();
    }

    public async UniTask<T> Load<T, E>(E id)
        where E : struct, IComparable
    {
        var structName = id.GetType().Name;
        var idName = id.ToString();
        var path = $"{structName}/{idName}";

        return await Load<T>(path);
    }
}