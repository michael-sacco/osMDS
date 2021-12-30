using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static HelperFunctions;

public class AsteroidEntity : MonoBehaviour, LivingEntity
{
    public Action<EntityType> onDestroyAsteroid;

    [SerializeField]
    private GameObject asteroidDestroyedParticleSystem = null;

    private int maxHP = 1;
    private int currentHP = 1;

    [SerializeField] EntityType entityType = EntityType.Asteroid;
    [SerializeField] private GameObject healthDrop;
    [SerializeField, Range(0f, 100f)] private float healthDropRatePercent = 20f;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void HitBy(EntityType type)
    {
        switch (type)
        {
            case EntityType.Boundary:
                HitObject(type);
                break;
            case EntityType.Player:
                HitObject(type);
                break;
            case EntityType.Bullet:
                HitObject(type);
                break;
            default:
                break;
        }   
    }

    public EntityType GetEntityType()
    {
        return entityType;
    }

    private void HitObject(EntityType type)
    {
        TakeDamage(1, type);
    }

    private void TakeDamage(int dmg, EntityType type)
    {
        currentHP -= dmg;
        Instantiate(asteroidDestroyedParticleSystem, transform.position + asteroidDestroyedParticleSystem.transform.position, Quaternion.identity);
        if (currentHP <= 0)
            Die(type);
    }

    private void Die(EntityType type)
    {
        if(type == EntityType.Bullet)
        {
            float random = UnityEngine.Random.Range(0f, 100f);
            if (random <= healthDropRatePercent)
            {
                Instantiate(healthDrop, transform.position, Quaternion.identity);
            }
        }

        onDestroyAsteroid(type);
        Destroy(gameObject);
    }
}
