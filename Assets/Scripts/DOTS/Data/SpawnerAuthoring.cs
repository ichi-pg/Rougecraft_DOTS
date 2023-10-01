using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct SpawnerData : IComponentData
{
    public Entity SpawnPrefab;
    public float3 SpawnPosition;
    public float NextSpawnTime;
    public float SpawnSpanTime;
}

public class SpawnerAuthoring : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] Transform spawnerTransform;
    [SerializeField] float spawnSpanTime;

    class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new SpawnerData
            {
                SpawnPrefab = GetEntity(authoring.spawnPrefab, TransformUsageFlags.Dynamic),
                SpawnPosition = authoring.spawnerTransform.position,
                NextSpawnTime = 0.0f,
                SpawnSpanTime = authoring.spawnSpanTime,
            });
        }
    }
}
