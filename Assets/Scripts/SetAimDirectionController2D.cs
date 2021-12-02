using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAimDirectionController2D : MonoBehaviour
{
    [SerializeField]
    private Transform playerRenderer = null;

    Camera mainCamera;

    float aimDirection = 0f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    private AudioClip onShootSound = null;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        aimDirection = SetAimDirection();
        Shoot(aimDirection);
        SetRendererRotation(aimDirection);
    }

    private float SetAimDirection()
    {
        Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPoint = transform.position;

        float deltaX = worldPoint.x - playerPoint.x;
        float deltaY = worldPoint.y - playerPoint.y;
        float radians = Mathf.Atan2(deltaY, deltaX);
        float degrees = (Mathf.Rad2Deg * radians) - 90.0f;
        
        return degrees;
    }

    private void SetRendererRotation(float angle)
    {
        playerRenderer.localRotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Shoot(float angle)
    {
        if (!Input.GetMouseButtonDown(0)) return;

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, angle));
        newBullet.GetComponent<ProjectileController2D>().InheritVelocity(GetComponent<PlayerController2D>().Velocity);
        PlayShootSound();
    }

    private void PlayShootSound()
    {
        GetComponent<AudioSource>().PlayOneShot(onShootSound);
    }
}
