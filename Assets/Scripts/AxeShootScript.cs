using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeShootScript : MonoBehaviour     
{
    public Rigidbody2D AxeRigid;
    private float shootForce=7.5f;
    void Start()
    {
        AxeRigid=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AxeRigid.velocity= transform.right*shootForce;
        Destroy(gameObject,5f);    
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
       Vector2 sidePoint=collision.GetContact(0).normal;
       if (sidePoint.x != 0)
       {
            Destroy(gameObject);
       }
    }
}

