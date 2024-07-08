using UnityEngine;

public class SceneData
{
    public ScenePointData[] Points;
    public SceneObjectData[] Objects;
    public string[] VideoLinks;
}

public struct ScenePointData
{
    public Vector3 AnchorPosition;
    public Quaternion DefaultRotation;
    public Vector3 RotationLimitsDegree;

}

public struct SceneObjectData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public int SceneObjectId;
    public SceneObjectType ObjectType;
}

public enum SceneObjectType
{
    Flower
}
