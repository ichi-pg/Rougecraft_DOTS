using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct InputReceiver : IComponentData
{
    public float2 MoveDirection;
}

public class InputReceiverAuthoring : MonoBehaviour
{
    class InputReceiverBaker : Baker<InputReceiverAuthoring>
    {
        public override void Bake(InputReceiverAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new InputReceiver
            {
                MoveDirection = new float2(0.0f, 0.0f)
            });
        }
    }
}
