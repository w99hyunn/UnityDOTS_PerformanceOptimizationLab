using Unity.Burst;
using Unity.Entities;
using UnityEngine;

partial struct PlayerInputSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float h = Input.GetAxis("Horizontal");

        foreach (var dir in SystemAPI.Query<RefRW<MoveDirection>>().WithAll<PlayerTag>())
        {
            dir.ValueRW.value = new Unity.Mathematics.float3(h, 0, 0);
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
