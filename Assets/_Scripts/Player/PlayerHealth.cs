using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

     [SerializeField] private Image healthBar;
     [SerializeField] private float MaxHP;
     public float currentHP;



     private void Start()
     {
         currentHP = MaxHP;
         healthBar.fillAmount = 1;
     }
     
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            
            currentHP -= other.gameObject.GetComponent<Damage>().damage;
            Destroy(other.gameObject);
            healthBar.fillAmount = currentHP / MaxHP;
            if (currentHP <= 0)
            {
                GameManager.sharedInstance.GameOver();
            }
        }
    }


}
