using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct Tracer : IComponentData
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
            AddComponent(entity, new Tracer
            {
                TargetPosition = new float3(0.0f, 0.0f, 0.0f),
            });
        }
    }
}
