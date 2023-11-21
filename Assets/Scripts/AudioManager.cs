using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance {get; private set;}
    private AudioSource audioSource;
    [SerializeField] private AudioClip totemCoin;
    [SerializeField] private AudioClip axeshootSound;
    private void Awake()
    {
        if(AudioInstance==null)
        {
            AudioInstance=this;
            audioSource=GetComponent<AudioSource>();   
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Soundtotem()
    {
        audioSource.PlayOneShot(totemCoin);
    }
    public void AxeSound()
    {
        audioSource.PlayOneShot(axeshootSound);
    }
}
