using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BoxScript : MonoBehaviour
{   
    //Caja Vacia
    private bool EmptyBox;
    [SerializeField] private Sprite BoxEmpty;
    //Rebote
    private float bounceTime=1f;
    private float bounceDuration=0.25f;
    private bool Bounce;
    //Destrucción Caja 
    public bool isDestructible;
    public GameObject DestroyBoxPreFab; 
    //Tiene Totems Dentro
    public GameObject itemBox;
    public int totemInbox;
    public GameObject TotemBoxPreFab; 
    
   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if (collision.CompareTag("HeadPlayer"))
        {
            //Debug.Log("Golpe de Cabeza");
            Player player =collision.transform.parent.GetComponent<Player>();
            if (isDestructible)
            {
                BoxDestroy();
            }
            else if(!EmptyBox)
            {
                if(totemInbox>0)
                    {
                        if(!Bounce)
                        {
                            Instantiate(TotemBoxPreFab,transform.position,Quaternion.identity);
                            totemInbox--;
                            GameManager.Instance.AddTotemsCoins();
                            BounceBox();
                            if (totemInbox<=0)
                            {
                                EmptyBox=true;
                            }
                        }
                    }
                else if (itemBox!=null)
                {
                    if(!Bounce)
                    {
                        itemStart();
                        BounceBox();
                        EmptyBox=true;
                    }
                }
            }
        } 
   }
   void BounceBox()
   {
        if (!Bounce)
        {
            StartCoroutine(boxBounce());
        }
   }
        IEnumerator boxBounce()
        {
            Bounce=true;
            Vector2 startPosition=transform.position;
            Vector2 finalPosition= (Vector2)transform.position + Vector2.up*0.5f;
                while (bounceTime<bounceDuration)
                    {
                        transform.position=Vector2.Lerp(finalPosition,startPosition,bounceTime/bounceDuration);
                        bounceTime+=Time.deltaTime;
                        yield return null;
                    }
            transform.position=finalPosition;
            bounceTime=0;
                while (bounceTime<bounceDuration)
                    {
                        transform.position=Vector2.Lerp(startPosition,finalPosition,bounceTime/bounceDuration);
                        bounceTime+=Time.deltaTime;
                        yield return null;
                    }
            transform.position=startPosition;
            Bounce=false;
            if (EmptyBox)
            {
                GetComponent<SpriteRenderer>().sprite=BoxEmpty;
            }
        }
    void BoxDestroy()
        {
            GameObject DestroyBox;
            DestroyBox=Instantiate(DestroyBoxPreFab,transform.position,Quaternion.identity);
            DestroyBox.GetComponent<Rigidbody2D>().velocity=new Vector2(0f,3f);
            Destroy(DestroyBox,2f);

            Destroy(this.gameObject,0.05f);
        }
   private void itemStart()
        {
            GameObject Item= Instantiate(itemBox,transform.position,Quaternion.identity);
            Item.GetComponent<Rigidbody2D>().velocity=new Vector2(3f,0.05f);
        }
}
