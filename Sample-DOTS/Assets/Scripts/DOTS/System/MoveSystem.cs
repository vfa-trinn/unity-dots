using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
         
        JobHandle jobHandle = Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeed) => {
            translation.Value.x += moveSpeed.value * deltaTime;
            if (translation.Value.x > 5) moveSpeed.value = -math.abs(moveSpeed.value);
            if(translation.Value.x < -5) moveSpeed.value = math.abs(moveSpeed.value);
        }).Schedule(inputDeps);

        return jobHandle;
    }
}
