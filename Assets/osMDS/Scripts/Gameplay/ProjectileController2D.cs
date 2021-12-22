using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;

public class ProjectileController2D : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    private Vector2 parentVelocity = Vector2.zero;

    public void InheritVelocity(Vector2 parentVelocity)
    {
        this.parentVelocity = parentVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.up * speed + new Vector3(parentVelocity.x, parentVelocity.y, 0)) * Time.deltaTime, Space.World);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(this + " collision enter -> " + collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out LivingEntity entity))
        {
            GetComponent<LivingEntity>().HitBy(entity.GetEntityType());
        }
    }
}
