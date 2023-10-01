using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct TracerData : IComponentData
{
    public float3 TargetPosition;
}

public class TracerAuthoring : MonoBehaviour
{
    class TracerBaker : Baker<TracerAuthoring>
    {
        public override void Bake(TracerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new TracerData
            {
                TargetPosition = new float3(0.0f, 0.0f, 0.0f),
            });
        }
    }
}
