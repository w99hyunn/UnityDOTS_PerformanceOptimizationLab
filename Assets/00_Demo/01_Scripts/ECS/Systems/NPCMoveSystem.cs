using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

partial struct NPCMoveSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float time = (float)SystemAPI.Time.ElapsedTime;

        foreach (var dir in SystemAPI.Query<RefRW<MoveDirection>>().WithAll<NpcTag>())
        {
            dir.ValueRW.value.x = math.sin(time);
            dir.ValueRW.value.y = math.cos(time);
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
