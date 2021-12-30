using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;

[RequireComponent(typeof(LivingEntity))]
public class HealthDrop : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out LivingEntity colliderEntity))
        {
            GetComponent<LivingEntity>().HitBy(colliderEntity.GetEntityType());
        }
    }
}
