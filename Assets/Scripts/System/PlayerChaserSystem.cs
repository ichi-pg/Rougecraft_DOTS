using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct PlayerChaserSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
    }

    public void OnDestroy(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        //TODO
        // var entity = SystemAPI.GetSingletonEntity<PlayerTag>();
        // var transform = SystemAPI.GetComponentRO<LocalTransform>(entity);
        new PlayerChaserJob
        {
            // TargetPosition = transform.ValueRO.Position,

        }.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct PlayerChaserJob : IJobEntity
{
    public float3 TargetPosition;

    void Execute(in EnemyTag tag, ref TargetChaser chaser)
    {
        chaser.TargetPosition = TargetPosition;
    }
}
