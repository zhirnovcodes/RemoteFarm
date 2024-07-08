public interface ISceneDataModel
{
    public ScenePointData GetPointData(int index);
    public SceneObjectData GetObjectData(int index);
    public string GetImageLink(int index);
    public int PointsCount { get; }
    public int ObjectsCount { get; }
}