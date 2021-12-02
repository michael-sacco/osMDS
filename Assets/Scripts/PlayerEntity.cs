using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static HelperFunctions;

public class PlayerEntity : MonoBehaviour, LivingEntity
{
    [SerializeField]
    private int maxHP = 5;
    [SerializeField]
    private int currentHP = 5;

    public int CurrentHP { get { return currentHP; } }

    [SerializeField]
    private int damageFromAsteroid = 1;

    [SerializeField]
    private int damageFromBoundary = 999;

    [SerializeField]
    private GameObject takeDamageParticleSystem = null;

    private float spawnTime = 0f;
    public float AliveTime { get { return Time.time - spawnTime; } }

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
        Destroy(gameObject);
    }


    private void PlayDamageSound()
    {
        GetComponent<AudioSource>().PlayOneShot(onPlayerDamageSound);
    }

}
