using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

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
        // foreach (var (tag, transform) in SystemAPI.Query<RefRO<PlayerTag>, RefRO<LocalTransform>>())
        // {
        new PlayerChaserJob
        {
            // TargetPosition = transform.Position,

        }.ScheduleParallel();
        // }
        //TODO PlayerのSingletonのTransformを取得
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
