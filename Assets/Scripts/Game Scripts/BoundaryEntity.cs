using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperFunctions;

public class BoundaryEntity : MonoBehaviour, LivingEntity
{
    [SerializeField]
    EntityType entityType = EntityType.Boundary;

    public void HitBy(EntityType type)
    {

    }

    public EntityType GetEntityType()
    {
        return entityType;
    }
}
