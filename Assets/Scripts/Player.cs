using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{  
    public static Player player {get; private set;}
    //Player Movimiento
    [SerializeField] private float moveSpeed;
    [SerializeField] private float DirX;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravity;
    [SerializeField] private float rayChecker;
    [SerializeField] private LayerMask Ground;
    private float Running;
    private bool isGrounded;
    //Componentes
    private Rigidbody2D myRb;
    private Animator myAnim;
    private SpriteRenderer render;
    //Acción de Disparo//
    [SerializeField] private float TimeActiveAxe;
    private bool AxeStart=false;
    public GameObject AxeShootPreFab;
    public Transform ShootPoint;
    //Upgrade
    private bool buffBeer;
    [SerializeField] private float buffActive;
    [SerializeField] private float speedUp;
    private void Start() 
    {
        myRb=GetComponent<Rigidbody2D>();
        myAnim=GetComponent<Animator>();
        render=GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() 
    {
        horizontalMovement();
    }
    private void Update() 
    {
        
        Jump();
        Animation(); 
        //Disparo// 
        if (AxeStart)
        {
            ShootAxe();
        }        
        //velocidad
        if (buffBeer) 
        {
            SpeedUpgrade();
        }
    }
    private void horizontalMovement()
    {
        //Movimiento
        DirX=Input.GetAxisRaw("Horizontal");
        myRb.velocity=new Vector2 (DirX*moveSpeed,myRb.velocity.y);
        //Rotar Personaje
        if (DirX>0)
        {
            transform.eulerAngles=Vector2.zero;
        }
        else if(DirX<0)
        {
            transform.eulerAngles=new Vector2(0f,180f);
        }    
    }
    //Salto
    private void Jump()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded==true))
            {
                myRb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);   
            }
        isGrounded = Physics2D.Raycast(transform.position,Vector2.down,rayChecker,Ground);  
         //Gravity 
            if (myRb.velocity.y>0)
                {
                    myRb.gravityScale=gravityScale;
                }
                else
                {
                    myRb.gravityScale=fallGravity;
                }
    } 
    //Animaciones
    private void Animation()
    {   
        myAnim.SetFloat("Running",Mathf.Abs(DirX));
        myAnim.SetBool("isGrounded",isGrounded);
    }
     //Accion de Disparo
    private void ActiveAxe()
    {
        AxeStart=true;
        StartCoroutine(deActiveAxe());
    }
        IEnumerator deActiveAxe()
        {
            yield return new WaitForSeconds(TimeActiveAxe);
            AxeStart=false;
        }
 
        //Triggers 
        private void OnTriggerEnter2D(Collider2D collision2D) 
        {
        //Hacha
            if (collision2D.gameObject.CompareTag("Axe"))
                {
                    //Debug.Log("Te armaste para peligros inesperados");
                    Destroy(collision2D.gameObject);
                    ActiveAxe(); 
                }
        //Cerverza/Potenciador
        if (collision2D.gameObject.CompareTag("Beer"))
            {     
                //Debug.Log("Te sientes mejor por una bebida fresca"); 
                Destroy(collision2D.gameObject);
                buffSpeed();
            }
        }
        //Colisiones
        private void OnCollisionEnter2D(Collision2D collision) 
        {
            if (collision.gameObject.CompareTag("Soup"))
            {
                    //Debug.Log("Nutritiva Comida");
                    Destroy(collision.gameObject);
                    SoupBuff();
            }
        }

    //Upgrade
    private void buffSpeed()
    {
        buffBeer=true;
        StartCoroutine(SpeedUpgrade());
    }
        IEnumerator SpeedUpgrade()
        {
            moveSpeed+=speedUp;
            yield return new WaitForSeconds(buffActive);
            moveSpeed-=speedUp;
            buffBeer=false;
        }         
    private void ShootAxe()
    {
        if(Input.GetButtonDown("Fire1"))
        {   
            GameObject AxeStart=Instantiate(AxeShootPreFab,ShootPoint.position,ShootPoint.rotation);
            AudioManager.AudioInstance.AxeSound();     
        }
    }
    private void SoupBuff()
    {
        GameManager.Instance.AddTotemsCoins();
        GameManager.Instance.AddLife();   
    } 
}
    