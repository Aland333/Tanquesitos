using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    public Image canvasHealthBar;
    public bool isSelected = false; //Para indicar controlar si el jugador ha seleccionado este tanque
    // haciendo click derecho

    private void Start()
    {
        currentHP = maxHP;
        healthBar.fillAmount = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            currentHP -= other.gameObject.GetComponent<Damage>().damage;
            Destroy(other.gameObject);
            healthBar.fillAmount = currentHP / maxHP;
            if (isSelected) //Si el tanque enemigo está seleccionado, lo que quiere decir que se ha de mostrar su vida
            // en el canvas
            {
                canvasHealthBar.fillAmount = currentHP / maxHP;
            }
            if (currentHP <= 0)
            {
                GameManager.sharedInstance.enemyDestroyed += 1;
                isSelected = false;
                Destroy(this.gameObject);
            }

        }
    }
    /// <summary>
    /// Este método es llamado desde el script de PlayerMovement y lo que hace es mostrar la barra de vida en el canvas
    /// del juego
    /// </summary>
    
    public void Selected()
    {

        canvasHealthBar = GameObject.FindGameObjectWithTag("EnemyHPBar").GetComponent<Image>();
        canvasHealthBar.fillAmount = currentHP / maxHP;
        isSelected = true;
    }

}
