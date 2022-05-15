using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    
    public GameObject shootingPoint;
    
    [Header("Bomba")]
    public GameObject Bomb;
    public float bombFireRate = 1;
    private float timeSinceLastBomb = 0;
    [Header("Balas")]
    public GameObject Bullet;
    public float bulletFireRate = 0.2f;
    private float timeSinceLastBullet = 0;
    private void Update()
    {
        ShootBomb();
        ShootBullet();
    }

    private void ShootBomb()
    {
        timeSinceLastBomb += Time.deltaTime;
        if (Input.GetAxisRaw("Fire") > 0 && timeSinceLastBomb > bombFireRate ) //Si se pulsa espacio y ha pasado
        // suficiente tiempo desde la última bomba
        {
            
            var projectile = Instantiate(Bomb, shootingPoint.transform.position, shootingPoint.transform.rotation);
            projectile.tag = "PlayerProjectile"; //Al intanciar la el proyectil le cambiamos la etiqueta
            timeSinceLastBomb = 0;
        }

    }
    private void ShootBullet()
    {
        
        timeSinceLastBullet += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeSinceLastBullet > bulletFireRate )//Si hace click izquierdo y ha pasado
            // suficiente tiempo desde el último disparo
        {
            var projectile = Instantiate(Bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
            projectile.tag = "PlayerProjectile";
            timeSinceLastBullet = 0;

        }
        
    }
}
