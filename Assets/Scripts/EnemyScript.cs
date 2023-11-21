using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision) 
    {    
        if (collision.gameObject.CompareTag("Player"))
        {   
            Player player=collision.transform.GetComponent<Player>();
            {   
                GameManager.Instance.receiveDamage();
            }               
        }   
        if(collision.gameObject.layer==LayerMask.NameToLayer("ShootAttack"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger) 
    {
         if (trigger.gameObject.CompareTag("pjFeet"))
        {
            Destroy(this.gameObject);
        }
    }
       
    
}
