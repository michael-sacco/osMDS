using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;

public class PlayerController2D : MonoBehaviour
{   
    private Vector2 playerInput = Vector2.zero;
    public Vector2 PlayerInput { get { return playerInput; } }

    private Vector2 velocity = Vector2.zero;
    public Vector2 Velocity { get { return velocity; } }


    [SerializeField]
    private float maxAcceleration = 1f;
    [SerializeField]
    private float maxVelocity = 1f;

    public float MaxVelocity { get { return maxVelocity; } }
    public float Speed { get { return Vector3.Magnitude(Velocity); } }
    public float Speed01 { get { return Speed / MaxVelocity; } }

    
    void Update()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        Vector2 targetVelocity = playerInput * maxVelocity;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        float maxSpeedChangeX = maxSpeedChange;
        float maxSpeedChangeY = maxSpeedChange;

        if (targetVelocity.x == 0f)
            maxSpeedChangeX *= 0.1f;


        if (targetVelocity.y == 0f)
            maxSpeedChangeY *= 0.1f;


        velocity.x = Mathf.MoveTowards(velocity.x, targetVelocity.x, maxSpeedChangeX);
        velocity.y = Mathf.MoveTowards(velocity.y, targetVelocity.y, maxSpeedChangeY);
        Vector2 displacement = velocity * Time.deltaTime;
        
        transform.Translate(displacement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out LivingEntity entity))
        {
            GetComponent<LivingEntity>().HitBy(entity.GetEntityType());
        }
    }
}
