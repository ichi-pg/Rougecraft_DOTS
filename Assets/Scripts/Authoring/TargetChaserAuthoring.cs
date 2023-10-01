using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct TargetChaser : IComponentData
{
    public float MoveSpeed;
    public float3 TargetPosition;
}

public class TargetChaserAuthoring : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    class TargetChaserBaker : Baker<TargetChaserAuthoring>
    {
        public override void Bake(TargetChaserAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new TargetChaser
            {
                MoveSpeed = authoring.moveSpeed,
                TargetPosition = new float3(0.0f, 0.0f, 0.0f),
            });
        }
    }
}
