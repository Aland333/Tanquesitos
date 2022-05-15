using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    private Ray ray;
    private RaycastHit hit;
    public LayerMask layerObject;
    void Update()
    {
        Movement();
        Rotation();
        if (Input.GetMouseButtonDown(1))
        {
            autoAim();
        }
    }

    /// <summary>
    /// Método encargado de la rotación del taque
    /// </summary>
    private void Rotation()
    {
        float h = Input.GetAxis("Horizontal");
        
        transform.Rotate(h * rotationSpeed *  Time.deltaTime * Vector3.up);
    }
    /// <summary>
    /// Método encargado del movimiento del tanque
    /// </summary>
    private void Movement()
    {
        float v = Input.GetAxis("Vertical");
        
        transform.Translate(v * speed * Time.deltaTime * Vector3.forward);
    }

    /// <summary>
    /// Método que hace que cuando se haga click derecho sobre un enemigo se guire automáticamente el tanque hacia el
    /// y que además salga la vida de este tanque enemigo
    /// </summary>
    private void autoAim()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Obtenemos un rayo que sale de la cámara hasta
        //la posición del ratón en el juego
        if (Physics.Raycast(ray, out hit, 100,  layerObject )) 
        {
            transform.DOLookAt(hit.collider.transform.position, 1);
            hit.collider.gameObject.GetComponent<EnemyHealth>().Selected();

        }
        
    }
}
