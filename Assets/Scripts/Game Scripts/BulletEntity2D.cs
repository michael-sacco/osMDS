using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;
public class BulletEntity2D : MonoBehaviour, LivingEntity
{
    EntityType type = EntityType.Bullet;

    [SerializeField]
    float maxLifetime = 5f;
    float timeAlive = 0f;


    private void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= maxLifetime)
            Die();

    }
    public void HitBy(EntityType type)
    {
        switch (type)
        {
            case EntityType.Player:
                break;
            case EntityType.Boundary:
                HitObject();
                break;
            case EntityType.Asteroid:
                HitObject();
                break;
        }
    }

    private void HitObject()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public EntityType GetEntityType()
    {
        return type;
    }
}
