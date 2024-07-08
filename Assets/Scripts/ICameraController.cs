using UnityEngine;

public interface ICameraController
{
    void Enable();
    void Disable();

    void SetRotationLimits(Vector3 angles);

    void SetLookRotation(Quaternion rotation);
    void SetPosition(Vector3 position);
}
