using Cysharp.Threading.Tasks;
using System;

public interface IResourcesService
{
    UniTask<T> Load<T>(string path);
    UniTask<T> Load<T, E>(E id) where E : struct, IComparable;

}
