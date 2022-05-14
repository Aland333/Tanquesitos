using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    
    public GameObject player;

    [SerializeField] private float speed = 5;
    private EnemyFire enemyFire;
    [SerializeField] private float distanceToMoveForward = 4;
    [SerializeField] private float distanceToMoveBackward = 3;
    [SerializeField] private float shootDistance = 10;
    
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyFire = GetComponent<EnemyFire>();
    }
    
    void Update()
    {
        CheckDistance();
        Shoot();
    }
    /// <summary>
    /// Comprueba la distancia hasta el jugador, si es mayor que un valor irá hacia el player y si es menor que otro
    /// valor se hechará hacia atras.
    /// </summary>
    private void CheckDistance()
    {
        if((Vector3.Distance(transform.position, player.transform.position) > distanceToMoveForward))
        {
            MoveDirection(true);
        }else if (Vector3.Distance(transform.position, player.transform.position) < distanceToMoveBackward)
        {
            MoveDirection(false);
        }
    }
    
    /// <summary>
    /// Gira y mueve el enemy en la dirección o en la dirección contraria de donde está el player
    /// </summary>
    /// <param name="forward">Si es true se acerda, si es false se aleja</param>
    private void MoveDirection(bool forward)
    {
        transform.LookAt(player.transform);

        if (forward)
        {
            transform.Translate(Vector3.forward * speed *Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed *Time.deltaTime);

        }



    }

    /// <summary>
    /// Si está a distancia de tiro dispara
    /// </summary>
    private void Shoot()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < shootDistance)
        {
            transform.LookAt(player.transform);
            enemyFire.ShootBomb();
        }
    }
}
