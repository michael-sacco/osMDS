using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerData : MonoBehaviour
{
    [SerializeField]
    PlayerController2D controller2D;

    [SerializeField]
    PlayerEntity livingEntity;

    [SerializeField]
    AsteroidSpawner asteroidSpawner;


    [HideInInspector] public Vector2 Velocity;
    [HideInInspector] public Vector2 PlayerInput;
    [HideInInspector] public Vector2 Position;
    [HideInInspector] public int CurrentHP;
    [HideInInspector] public float AliveTime;
    [HideInInspector] public int AsteroidsKilled;
    [HideInInspector] public int TotalScore;

    // Update is called once per frame
    void Update()
    {
        if (controller2D == null || livingEntity == null)
            return;

        if (livingEntity.EntityState == HelperFunctions.EntityState.Dead)
            return;

        if (controller2D != null && livingEntity != null)
        {
            Velocity = controller2D.Velocity;
            PlayerInput = controller2D.PlayerInput;
            Position = new Vector2(controller2D.transform.position.x, controller2D.transform.position.y);
            CurrentHP = livingEntity.CurrentHP;
            AliveTime = livingEntity.AliveTime;
            AsteroidsKilled = asteroidSpawner.AsteroidsKilled;
            TotalScore = GetScore();
        }
    }

    int GetScore()
    {
        return (int)((AliveTime * AliveTime * 0.1) + AsteroidsKilled * 100);
    }
}
