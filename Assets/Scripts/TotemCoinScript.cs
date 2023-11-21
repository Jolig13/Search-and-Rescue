using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemCoinScript : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {  
            Destroy(this.gameObject); 
            GameManager.Instance.AddTotemsCoins();
            //Debug.Log("Sumaste una moneda del bosque");
        }
    }
}