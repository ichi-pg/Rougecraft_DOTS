using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;

[BurstCompile]
public partial struct InputMoverSystem : ISystem
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
        var receiver = SystemAPI.GetSingleton<InputReceiver>();
        var direction = receiver.MoveDirection;
        new InputMoverJob
        {
            DeltaTime = Time.deltaTime,
            MoveDirection = new float3(direction.x, direction.y, 0.0f),

        }.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct InputMoverJob : IJobEntity
{
    public float DeltaTime;
    public float3 MoveDirection;

    void Execute(in InputMover mover, ref LocalTransform transform)
    {
        transform.Position += MoveDirection * mover.MoveSpeed * DeltaTime;
    }
}
