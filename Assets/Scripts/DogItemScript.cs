using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DogItemScript : MonoBehaviour
{
    [SerializeField, TextArea(3,5)] private string[] linesDialogue;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text DogItemDialogue; 
    private bool touchItem;
    private bool didDialoguing;
    private int dialogueIndexlines;
    private float textWait=0.05f;
    private void Update() 
    {   
        if (touchItem==true && Input.GetMouseButtonDown(0))
        {
            if(!didDialoguing)
                {
                    DialogueStart(); 
                }
            else if (DogItemDialogue.text==linesDialogue[dialogueIndexlines])
                {
                    NextlineDialogue();
                }
            else 
                {
                    StopAllCoroutines();
                    DogItemDialogue.text=linesDialogue[dialogueIndexlines];
                }
        }
    }
    private void DialogueStart()
    {
        didDialoguing=true;
        dialoguePanel.SetActive(true);
        dialogueIndexlines=0;
        Time.timeScale=0f;
        StartCoroutine(ShowDialogue());
    }
    private void NextlineDialogue()
    {
        dialogueIndexlines++;
        if (dialogueIndexlines<linesDialogue.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            didDialoguing=false;
            dialoguePanel.SetActive(false);
            Time.timeScale=1f;
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    private IEnumerator ShowDialogue()
    {
        DogItemDialogue.text = string.Empty;
        foreach (char ch in linesDialogue[dialogueIndexlines])
        {
            DogItemDialogue.text+=ch;
            yield return new WaitForSecondsRealtime(textWait);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {   
            touchItem=true;
        }    
    }
    
}
