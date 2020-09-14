using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class RotateSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rotation, ref RotateComponent rotateComponent) => {
            quaternion yRot = quaternion.RotateZ(math.radians(rotateComponent.value * Time.DeltaTime));
            rotation.Value = math.mul(rotation.Value, yRot);
        });
    }
}
