using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab = null;

    [SerializeField]
    private BoundaryController2D boundaryController2D = null;

    [SerializeField]
    private Transform playerTransform = null;

    [SerializeField]
    private int minNumberOfAsteroids = 3;

    [SerializeField]
    private int maxNumberOfAsteroids = 20;


    [SerializeField]
    private int asteroidRemap = 200;
    private int maxAsteroidCount = 3;

    private int asteroidCount = 0;


    [SerializeField]
    private float playerBufferDistance = 2f;

    private int asteroidsKilled = 0;
    public int AsteroidsKilled { get { return asteroidsKilled; } }

    public Action<int> onAsteroidKilledByPlayer;

    [SerializeField]
    private AudioClip onAsteroidDestroyedSound;

    private void Start()
    {
        asteroidsKilled = 0;
        asteroidCount = 0;
        maxAsteroidCount = minNumberOfAsteroids;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
            AsteroidManagement();
    }

    void AsteroidManagement()
    {
        if (asteroidCount < maxAsteroidCount)
        {
            UpdateMaxAsteroidCount();

            if (CreateNewAsteroid())
                asteroidCount++;
        }
    }

    void UpdateMaxAsteroidCount()
    {
        maxAsteroidCount = (int)Mathf.Lerp((float)minNumberOfAsteroids, (float)maxNumberOfAsteroids, ((float)AsteroidsKilled / (float)asteroidRemap));
    }

    bool CreateNewAsteroid()
    {
        if (boundaryController2D != null)
        {
            Vector2 targetPosition = HelperFunctions.GetRandomNormalizedVector2() * (boundaryController2D.TempRadius - boundaryController2D.DiscSize);

            bool asteroidIsSufficientlyFarFromPlayer = Vector2.Distance(targetPosition, playerTransform.position) >= playerBufferDistance ? true : false;
            if (asteroidIsSufficientlyFarFromPlayer)
            {
                GameObject newAsteroid = Instantiate(asteroidPrefab, targetPosition, Quaternion.identity);

                if (newAsteroid.TryGetComponent(out AsteroidEntity asteroidEntity))
                {
                    asteroidEntity.onDestroyAsteroid += OnAsteroidDestroyed;
                    return true;
                }
            }
        }

        return false;
    }

    private void OnAsteroidDestroyed(HelperFunctions.EntityType type)
    {
        if (type == HelperFunctions.EntityType.Bullet) 
            PlayedKilledAsteroid();

        asteroidCount--;
        PlayAsteroidDestroyedSound();
    }

    private void AddScore(int amount)
    {
        asteroidsKilled += amount;
    }

    private void PlayedKilledAsteroid()
    {
        AddScore(1);
        onAsteroidKilledByPlayer(AsteroidsKilled);
    }

    private void PlayAsteroidDestroyedSound()
    {
        GetComponent<AudioSource>().PlayOneShot(onAsteroidDestroyedSound);
    }
}
