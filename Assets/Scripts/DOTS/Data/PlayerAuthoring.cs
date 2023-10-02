using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct PlayerData : IComponentData
{
}

public class PlayerAuthoring : MonoBehaviour
{
    class PlayerBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new PlayerData
            {
            });
        }
    }
}
