using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct ChaserData : IComponentData
{
    public float3 TargetPosition;
    public float MoveSpeed;
}

public class ChaserAuthoring : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    class ChaserBaker : Baker<ChaserAuthoring>
    {
        public override void Bake(ChaserAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new ChaserData
            {
                TargetPosition = new float3(0.0f, 0.0f, 0.0f),
                MoveSpeed = authoring.moveSpeed,
            });
        }
    }
}
