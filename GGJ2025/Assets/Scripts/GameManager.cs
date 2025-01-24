using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon.Main.Bubble;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    public PlayerManager playerManager;
    public List<Spawner> spawners;

    void Start()
    {
        PlayAudio();
        playerManager.OnDieAction += StopGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayAudio()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void StopGame()
    {
        audioSource.Stop();
        foreach(var spawner in spawners)
            spawner.gameObject.SetActive(false);
    }


}
