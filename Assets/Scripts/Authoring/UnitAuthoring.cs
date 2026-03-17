using Unity.Entities;
using UnityEngine;

public class UnitAuthoring : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    class Baker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new MoveSpeed { value = authoring.speed });
            AddComponent(entity, new MoveDirection { value = authoring.direction });

            Debug.Log("baked entity: " + entity);
        }
    }
}
