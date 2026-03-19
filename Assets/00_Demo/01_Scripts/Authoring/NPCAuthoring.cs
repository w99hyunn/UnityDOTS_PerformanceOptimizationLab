using Unity.Entities;
using UnityEngine;

public class NPCAuthoring : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    class Baker : Baker<NPCAuthoring>
    {
        public override void Bake(NPCAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new MoveSpeed { value = authoring.speed });
            AddComponent(entity, new MoveDirection { value = authoring.direction });
            AddComponent(entity, new NpcTag());
            Debug.Log("baked npc entity: " + entity);
        }
    }
}
