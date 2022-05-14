using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProyectile : MonoBehaviour
{

    private Rigidbody rg;


    [SerializeField] private float forceValue;
    // Start is called before the first frame update

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rg.AddRelativeForce(new Vector3(0,0.5f,1.5f) *forceValue ); //La bomba va tener un tiro parabólico y para
        // le añadimos una fuerza 
        Destroy(gameObject, 3);
    }
}
