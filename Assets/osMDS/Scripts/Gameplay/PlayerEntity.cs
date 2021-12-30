using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static HelperFunctions;

public class PlayerEntity : MonoBehaviour, LivingEntity
{
    [SerializeField] private int maxHP = 5;
    [SerializeField] private int currentHP = 5;
    
    public int CurrentHP { get { return currentHP; } }

    [SerializeField]
    private int damageFromAsteroid = 1;

    [SerializeField]
    private int damageFromBoundary = 999;

    [SerializeField] private int healthFromDrop = 1;

    [SerializeField]
    private GameObject takeDamageParticleSystem = null;

    private float spawnTime = 0f;
    public float AliveTime { get { return Time.time - spawnTime; } }

    private EntityState entityState = EntityState.Alive;
    public EntityState EntityState { get { return entityState; } }

    public Action onPlayerDie;

    [SerializeField]
    private EntityType entityType;

    [SerializeField]
    AsteroidSpawner asteroidSpawner;

    [SerializeField]
    private AudioClip onPlayerDamageSound;

    // Start is called before the first frame update
    void Start()
    {
        entityState = EntityState.Alive;
        currentHP = maxHP;
        spawnTime = Time.time;
        asteroidSpawner.onAsteroidKilledByPlayer += AsteroidKilledByPlayer;
    }

    private void AsteroidKilledByPlayer(int totalCount)
    {
        if (totalCount % 20 == 0 && currentHP < maxHP)
            currentHP++;
    }

    public void HitBy(EntityType type)
    {
        switch (type)
        {
            case EntityType.Asteroid:
                HitAsteroid();
                break;
            case EntityType.Boundary:
                HitBoundary();
                break;
            case EntityType.Drop:
                HitDrop();
                break;
            default:
                break;
        }
    }
    
    public EntityType GetEntityType()
    {
        return entityType;
    }

    public void HitAsteroid()
    {
        TakeDamage(damageFromAsteroid);
    }

    public void HitBoundary()
    {
        TakeDamage(damageFromBoundary);
    }

    public void HitDrop()
    {
        ReceiveHealth(healthFromDrop);
    }

    private void ReceiveHealth(int hp)
    {
        currentHP = Mathf.Min(currentHP + hp, maxHP);
    }

    private void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        Debug.Log("take damage - new hp: " + currentHP);
        PlayDamageSound();
        Instantiate(takeDamageParticleSystem, transform.position + takeDamageParticleSystem.transform.position, Quaternion.identity);
        if (currentHP <= 0)
            Die();
    }

    private void Die()
    {
        onPlayerDie();
        entityState = EntityState.Dead;
        gameObject.SetActive(false);
    }


    private void PlayDamageSound()
    {
        GetComponent<AudioSource>().PlayOneShot(onPlayerDamageSound);
    }

}
