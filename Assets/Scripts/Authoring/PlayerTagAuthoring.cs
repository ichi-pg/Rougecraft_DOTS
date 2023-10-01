using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct PlayerTag : IComponentData
{
}

public class PlayerTagAuthoring : MonoBehaviour
{
    class PlayerTagBaker : Baker<PlayerTagAuthoring>
    {
        public override void Bake(PlayerTagAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new PlayerTag
            {
            });
            //TODO GameObjectをEntityとしてInstantiate
        }
    }
}
