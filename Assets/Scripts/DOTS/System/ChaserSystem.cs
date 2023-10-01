using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;

[BurstCompile]
public partial struct ChaserSystem : ISystem
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
        new ChaserJob
        {
            DeltaTime = Time.deltaTime,

        }.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct ChaserJob : IJobEntity
{
    public float DeltaTime;

    void Execute(in ChaserData chaser, ref LocalTransform transform)
    {
        var direction = math.normalize(chaser.TargetPosition - transform.Position);
        transform.Position += direction * chaser.MoveSpeed * DeltaTime;
    }
}
