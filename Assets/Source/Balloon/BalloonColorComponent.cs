﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public sealed class BalloonColorComponent : IComponent
{
    public Color Value;
}