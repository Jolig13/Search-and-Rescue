using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private float autoSpeed=2f;
    private Rigidbody2D rb2D;
    private void Awake() 
    {
        rb2D=GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        if (rb2D.velocity.x>-0.1f && rb2D.velocity.x<0.1f)
        {
            autoSpeed=-autoSpeed;
        }    
        rb2D.velocity=new Vector2(autoSpeed,rb2D.velocity.y);
    }
}
