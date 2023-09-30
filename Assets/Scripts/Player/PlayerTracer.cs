using UnityEngine;
using Unity.Entities;

public class PlayerTracer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    void Update()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var query = entityManager.CreateEntityQuery(typeof(Tracer));
        var entity = query.GetSingletonRW<Tracer>();
        entity.ValueRW.TargetPosition = playerTransform.position;
    }
}
