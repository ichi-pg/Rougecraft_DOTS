using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;

[BurstCompile]
public partial struct EntitySpawnerSystem : ISystem
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
        var buffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        var writer = buffer.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
        new EntitySpawnerJob
        {
            EntityWriter = writer,
            ElapsedTime = (float)SystemAPI.Time.ElapsedTime,

        }.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct EntitySpawnerJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter EntityWriter;
    public float ElapsedTime;

    void Execute([ChunkIndexInQuery] int chunkIndex, ref EntitySpawner spawner)
    {
        if (ElapsedTime < spawner.NextSpawnTime)
        {
            return;
        }
        var entity = EntityWriter.Instantiate(chunkIndex, spawner.SpawnPrefab);
        var spawnPosition = LocalTransform.FromPosition(spawner.SpawnPosition);
        EntityWriter.SetComponent(chunkIndex, entity, spawnPosition);
        spawner.NextSpawnTime = ElapsedTime + spawner.SpawnSpanTime;
    }
}
