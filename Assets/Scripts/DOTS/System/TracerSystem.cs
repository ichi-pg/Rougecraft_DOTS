using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

[BurstCompile]
public partial struct TracerSystem : ISystem
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
        var tracer = SystemAPI.GetSingleton<TracerData>();
        new TracerJob
        {
            TargetPosition = tracer.TargetPosition,

        }.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct TracerJob : IJobEntity
{
    public float3 TargetPosition;

    void Execute(ref ChaserData chaser)
    {
        chaser.TargetPosition = TargetPosition;
    }
}
