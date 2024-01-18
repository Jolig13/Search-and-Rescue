using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD HudInstance {get; private set;}
    public TextMeshProUGUI Totems;
    public TextMeshProUGUI totalLife; 
    public GameObject[] Hearts;
    private void Awake() 
     {
        if(HudInstance==null)
        {
            HudInstance=this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void ActualyLife()
    {
        if (GameManager.Instance.Life>=0)
        {
            totalLife.text= "x"+ GameManager.Instance.Life.ToString();
            if (GameManager.Instance.Life==0)
            {
                totalLife.text="x"+GameManager.Instance.Life.ToString();
            }
        }
    }
        public void totemsCoin()
    {
        Totems.text ="x"+ GameManager.Instance.totemScore.ToString();
    }
}
