using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerEntity player;
    [SerializeField, Range(0f, 1f)] float lerpAmount = 0.001f;
    [SerializeField] Camera cam;
    [SerializeField, Range(0f, 1f)] float mouseInfluenceAmount = 0.3f;

    [SerializeField] float camLerpAdj = 0.01f;
    private void OnValidate()
    {
        camLerpAdj = lerpAmount * lerpAmount;
    }

    void LateUpdate()
    {
        if(player.EntityState == HelperFunctions.EntityState.Alive)
        {
            SmoothFollow();
        }
    }

    void SmoothFollow()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 targetPos = Vector2.Lerp(playerPos, mousePos, mouseInfluenceAmount);

        

        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 cameraTarget = Vector2.Lerp(currentPos, targetPos, camLerpAdj);
        transform.position = new Vector3(cameraTarget.x, cameraTarget.y, transform.position.z);
    }
}
