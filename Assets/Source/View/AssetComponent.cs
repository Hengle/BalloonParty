using Entitas;
using UnityEngine;

/// <summary>
/// This component represents the name path for Unity layer assets
/// The root folder used to asset components as of now is the
/// <see cref="Resources"/> path
/// </summary>
public sealed class AssetComponent : IComponent
{
    public string Value;
}