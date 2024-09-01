using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    [Header("Score Elements")]
    public int score;
    public int highscore;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public TMP_Text gameOverPanelScoreText;
    public TMP_Text gameOverPanelHighScoreText;


    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;
    public AudioClip bombSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps the GameManager alive across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures there's only one instance of GameManager
        }

        // Advertisement.Initialize("47474747");
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        GetHighscore();
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Best: " + highscore.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score; // Update the highscore variable
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save(); // Save the updated highscore to PlayerPrefs
            highscoreText.text = "Best: " + highscore.ToString();
        }
    }

    public void OnBombHit()
    {
        // Advertisement.Show();
        PlayBombSound();
        Time.timeScale = 0;

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + highscore.ToString();
        gameOverPanel.SetActive(true);


        // Deactive scores of the main game play
        scoreText.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(false);




        Debug.Log("Bomb hit");
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        // Active scores of the main game play
        scoreText.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(true);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

    public void PlayBombSound()
    {
        audioSource.PlayOneShot(bombSound);
    }
}
