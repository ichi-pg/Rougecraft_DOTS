using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct InputMover : IComponentData
{
    public float MoveSpeed;
}

public class InputMoverAuthoring : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    class InputMoverBaker : Baker<InputMoverAuthoring>
    {
        public override void Bake(InputMoverAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new InputMover
            {
                MoveSpeed = authoring.moveSpeed,
            });
        }
    }
}
