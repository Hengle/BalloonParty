using UnityEngine;

/// <summary>
/// Represents accessors to the Unity layer
/// <see cref="Transform"/> properties
/// </summary>
public interface IUnityTransform : ILinkedView
{
    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
    Vector3 Scale { get; set; }

    Vector3 Up { get; set; }
    Vector3 Right { get; set; }
    Vector3 Forward { get; set; }
}