using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct HealthData : IComponentData
{
    public int HP;
    public int MaxHP;
}

public class HealthAuthoring : MonoBehaviour
{
    [SerializeField] int maxHP;

    class HealthBaker : Baker<HealthAuthoring>
    {
        public override void Bake(HealthAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new HealthData
            {
                HP = authoring.maxHP,
                MaxHP = authoring.maxHP,
            });
        }
    }
}
