﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace DOTS
{
    public class Main : MonoBehaviour
    {
        public int playerNumber = 10000;

        void Start()
        {
            Unity.Mathematics.Random rand = new Unity.Mathematics.Random(111);
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            Entity prefabEntity = entityManager.CreateEntityQuery(typeof(PrefabEntityComponent)).GetSingleton<PrefabEntityComponent>().prefabEnity;

            for (int i = 0; i < playerNumber; i++)
            {
                var instance = entityManager.Instantiate(prefabEntity);
                entityManager.SetComponentData(instance, new Translation { Value = new float3(rand.NextFloat(-5, 5), rand.NextFloat(-5, 5), 0) });              
                entityManager.SetComponentData(instance, new MoveSpeedComponent { value = rand.NextFloat(1, 3) });
            }
        }
    }
}
