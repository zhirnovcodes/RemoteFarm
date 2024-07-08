using System;
using UnityEngine;

public interface IInputService
{
    event Action RightButtonClicked;
    event Action BackButtonClicked;

    Ray GetInputRay();
    bool IsRaycastingTo(Collider collider);
}
