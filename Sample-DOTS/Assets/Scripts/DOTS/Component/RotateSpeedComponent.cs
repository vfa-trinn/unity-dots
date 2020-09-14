using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

[GenerateAuthoringComponent]
public struct RotateComponent : IComponentData
{
    public float value;
}