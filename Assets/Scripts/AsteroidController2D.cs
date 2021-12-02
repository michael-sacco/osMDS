using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;

public class AsteroidController2D : MonoBehaviour
{
    Vector2 velocity = Vector2.zero;
    [SerializeField]
    float maxSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = GetRandomNormalizedVector2() * maxSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        FloatAround();
    }

    private void FloatAround()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out LivingEntity entity))
        {
            GetComponent<LivingEntity>().HitBy(entity.GetEntityType());
        }
    }
}