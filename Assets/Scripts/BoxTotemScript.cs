using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTotemScript : MonoBehaviour
{
   private float bounceTime=0f;
   private float bounceDuration=0.5f;
    private void Start() 
        {
            StartCoroutine(TotemBoxAnimation());    
        }
    IEnumerator TotemBoxAnimation()
    {
        Vector2 startPosition=transform.position;
        Vector2 finalPosition= (Vector2)transform.position + Vector2.up*1.25f;
        while (bounceTime<bounceDuration)
        {
            transform.position=Vector2.Lerp(startPosition,finalPosition,bounceTime/bounceDuration);
            bounceTime+=Time.deltaTime;
            yield return null;
        }
        transform.position=finalPosition;
        bounceTime=0;
        while (bounceTime<bounceDuration)
        {
            transform.position=Vector2.Lerp(finalPosition,startPosition,bounceTime/bounceDuration);
            bounceTime+=Time.deltaTime;
            yield return null;
        }
        transform.position=startPosition;
        Destroy(gameObject);
   }
}