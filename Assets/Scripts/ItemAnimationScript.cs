using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimationScript : MonoBehaviour
{   
    public SpriteRenderer myRenderer;
    public Sprite[] sprites;
    public float frameTime;
    private int frameAnimation = 0; 
    void Awake()
    {
        myRenderer=GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
        {
            while (true)
            {
                myRenderer.sprite= sprites[frameAnimation];
                frameAnimation++;
                if (frameAnimation>=sprites.Length)
                {
                    frameAnimation=0;
                }
                yield return new WaitForSeconds(frameTime);
            }
        }   
}
