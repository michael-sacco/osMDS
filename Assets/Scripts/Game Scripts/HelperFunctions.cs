using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public enum EntityType
    {
        Player,
        Boundary,
        Asteroid,
        Bullet
    }

    public enum EntityState
    {
        Alive,
        Dead
    }


    public static bool NotifyHitByTag(Collision2D collision, EntityType type, GameObject thisGameObject)
    {
        if (collision.gameObject.TryGetComponent(out LivingEntity entity))
        {
            entity.HitBy(type);
            Debug.Log(thisGameObject.name + " hit " + collision.gameObject.name);
            return true;
        }


        return false;
    }


    public static Vector2 GetRandomNormalizedVector2()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector2 value = new Vector2(x, y);
        value = Vector2.ClampMagnitude(value, 1f);
        return value;
    }

    public interface LivingEntity
    {
        void HitBy(EntityType type);
        EntityType GetEntityType();
    }
}


