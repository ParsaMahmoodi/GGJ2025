using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] objects;   
    public AudioSource audioSource;
    public AudioClip themeAudio;

    void Start()
    {
        PlayAudio();

        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }

    void PlayAudio()
    {
        audioSource.clip = themeAudio;
        audioSource.Play();
        audioSource.loop = true;
    }
}
