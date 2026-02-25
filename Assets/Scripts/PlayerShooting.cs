using UnityEngine;
using UnityEngine.InputSystem;  // Important for the new system

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime;

    void Update()
    {
        // Check if Space key is pressed using the new Input System
        if (Keyboard.current.spaceKey.isPressed && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}