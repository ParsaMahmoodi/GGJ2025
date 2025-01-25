using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapon.Main.Bubble;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    public PlayerManager playerManager;
    public List<Spawner> spawners;
    public TextMeshProUGUI health;

    public TextMeshProUGUI highScoreText;

    private int highScore;
    private int currentScore = 0;
    private float elapsedTime = 0f;
    private float scoreUpdateInterval = 1f;


    void Start()
    {
        PlayAudio();
        playerManager.OnDieAction += StopGame;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= scoreUpdateInterval)
        {
            IncreaseScore(1);
            elapsedTime = 0f;
        }

        health.text = "HP: " + (playerManager._playerHealth.GetRatio() * 100).ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
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
        foreach (var spawner in spawners)
            spawner.gameObject.SetActive(false);

        Invoke(nameof(EndGame), 1.5f);
    }

    private void EndGame()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();

        SceneManager.LoadScene("StartScene");
    }

    public void IncreaseScore(int scoreDelta)
    {
        currentScore += scoreDelta;
    }
}
