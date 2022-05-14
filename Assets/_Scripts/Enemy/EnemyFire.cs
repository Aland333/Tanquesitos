using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
// Start is called before the first frame update
    [SerializeField] private GameObject Bomb;
    [SerializeField] private GameObject shootingPoint;
    [SerializeField] private float bombFireRate = 1;
    private float timeSinceLastBomb = 0;

    
    public void ShootBomb()
    {
        timeSinceLastBomb += Time.deltaTime;
        if (timeSinceLastBomb > bombFireRate)
        {
            var projectile = Instantiate(Bomb, shootingPoint.transform.position, shootingPoint.transform.rotation);
            projectile.tag = "EnemyProjectile";
            timeSinceLastBomb = 0;
        }

    }
    
}
