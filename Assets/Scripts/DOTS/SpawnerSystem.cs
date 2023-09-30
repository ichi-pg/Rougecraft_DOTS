using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
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
        var bufferSystem = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var writer = bufferSystem.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
        new SpawnerJob
        {
            Writer = writer,
            ElapsedTime = SystemAPI.Time.ElapsedTime,

        }.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct SpawnerJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter Writer;
    public double ElapsedTime;

    void Execute([ChunkIndexInQuery] int chunkIndex, ref Spawner spawner)
    {
        if (spawner.NextSpawnTime < ElapsedTime)
        {
            var entity = Writer.Instantiate(chunkIndex, spawner.SpawnPrefab);
            var spawnPosition = LocalTransform.FromPosition(spawner.SpawnPosition);
            Writer.SetComponent(chunkIndex, entity, spawnPosition);
            spawner.NextSpawnTime = (float)ElapsedTime + spawner.SpawnSpanTime;
        }
    }
}
