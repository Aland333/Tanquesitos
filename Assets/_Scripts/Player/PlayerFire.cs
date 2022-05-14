using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Bomb;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private float bombFireRate = 1;
    private float timeSinceLastBomb = 0;
    [SerializeField] private float bulletFireRate = 0.2f;
    private float timeSinceLastBullet = 0;
    private void Update()
    {
        ShootBomb();
        ShootBullet();
    }

    private void ShootBomb()
    {
        timeSinceLastBomb += Time.deltaTime;
        if (Input.GetAxisRaw("Fire") > 0 && timeSinceLastBomb > bombFireRate )
        {
            
            var projectile = Instantiate(Bomb, shootingPoint.transform.position, shootingPoint.transform.rotation);
            projectile.tag = "PlayerProjectile";
            timeSinceLastBomb = 0;
        }

    }
    private void ShootBullet()
    {
        
        timeSinceLastBullet += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeSinceLastBullet > bulletFireRate )
        {
            var projectile = Instantiate(Bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
            projectile.tag = "PlayerProjectile";
            timeSinceLastBullet = 0;

        }
        
    }
}
