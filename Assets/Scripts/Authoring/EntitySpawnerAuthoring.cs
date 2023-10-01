using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct EntitySpawner : IComponentData
{
    public Entity SpawnPrefab;
    public float3 SpawnPosition;
    public float NextSpawnTime;
    public float SpawnSpanTime;
}

public class EntitySpawnerAuthoring : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] float spawnSpanTime;

    class EntitySpawnerBaker : Baker<EntitySpawnerAuthoring>
    {
        public override void Bake(EntitySpawnerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new EntitySpawner
            {
                SpawnPrefab = GetEntity(authoring.spawnPrefab, TransformUsageFlags.Dynamic),
                SpawnPosition = authoring.transform.position,
                NextSpawnTime = 0.0f,
                SpawnSpanTime = authoring.spawnSpanTime,
            });
        }
    }
}
