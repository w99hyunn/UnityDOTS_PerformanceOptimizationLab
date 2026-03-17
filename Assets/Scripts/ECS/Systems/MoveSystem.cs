using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

partial struct MoveSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        Debug.Log("MoveSystem created");
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        foreach (var (transform, speed, dir) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>, RefRO<MoveDirection>>())
        {
            transform.ValueRW.Position += dir.ValueRO.value * speed.ValueRO.value * deltaTime; 
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
