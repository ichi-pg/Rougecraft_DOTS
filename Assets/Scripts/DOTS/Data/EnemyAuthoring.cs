using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct EnemyData : IComponentData
{
}

public class EnemyAuthoring : MonoBehaviour
{
    class EnemyBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new EnemyData
            {
            });
        }
    }
}
