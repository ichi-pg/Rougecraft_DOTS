using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct EnemyTag : IComponentData
{
}

public class EnemyTagAuthoring : MonoBehaviour
{
    class EnemyTagBaker : Baker<EnemyTagAuthoring>
    {
        public override void Bake(EnemyTagAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new EnemyTag
            {
            });
        }
    }
}
