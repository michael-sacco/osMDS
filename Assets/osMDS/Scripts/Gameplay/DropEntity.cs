using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;

public class DropEntity : MonoBehaviour, LivingEntity
{

    [SerializeField] EntityType entityType = EntityType.Drop;

    [SerializeField] private float lifetime = 5f;
    private float age = 0f;

    private void Update()
    {
        UpdateAge();
    }

    void UpdateAge()
    {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            Destroy(gameObject);
        }
    }

    public EntityType GetEntityType()
    {
        return entityType;
    }

    public void HitBy(EntityType type)
    {
        if(type == EntityType.Player)
        {
            HitByPlayer();
        }
    }

    void HitByPlayer()
    {
        Destroy(gameObject);
    }
}
