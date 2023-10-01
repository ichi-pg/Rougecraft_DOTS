using UnityEngine;
using Unity.Entities;

public class PlayerTracer : MonoBehaviour
{
    void Update()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var query = entityManager.CreateEntityQuery(typeof(TracerData));
        var entity = query.GetSingletonRW<TracerData>();
        entity.ValueRW.TargetPosition = transform.position;
    }
}
