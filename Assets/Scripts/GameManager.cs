using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int totemScore;
    public int Life;

    private void Awake() 
    {
        if(Instance==null)
        {
            Instance=this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start() 
    {
        totemScore=0;
        Life=3;
        HUD.HudInstance.ActualyLife();
    }
    public void receiveDamage()
    {   
        Life-=1;
        if (Life==0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        HUD.HudInstance.ActualyLife();   
    }
    public void AddTotemsCoins()
    {
        totemScore+=1;
        HUD.HudInstance.totemsCoin();
        AudioManager.AudioInstance.Soundtotem();
    }
    public void AddLife()
    {
        Life+=1;
        HUD.HudInstance.ActualyLife();
    }
}
