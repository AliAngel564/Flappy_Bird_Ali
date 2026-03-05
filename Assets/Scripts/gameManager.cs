using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    [Header("DEPENDENCIES")] 
    public GameObject PipeSpawner;
    public GameObject restartButton;
    public Player player;
    public GameObject ScoreBoard;
    public GameObject GetReady;
    public GameObject Tap;
    public Rigidbody2D playerRB;
    [Header("Score")] 
    public GameObject currentScore;
    public TextMeshProUGUI ScoreText;
    
    private int PlayerScore;
    private int HighScore = 0;
    private int middleScore = 0;
    private int lowScore = 0;
    public bool GameStarted = false;

    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        middleScore = PlayerPrefs.GetInt("middleScore");
        lowScore = PlayerPrefs.GetInt("lowScore");
        Time.timeScale = 1;
        playerRB.constraints = RigidbodyConstraints2D.FreezePositionY;
        GameStarted = false;
        GetReady.SetActive(true);
        Tap.SetActive(true);
        ScoreBoard.SetActive(false);
        currentScore.SetActive(false);
    }

    private void Update()
    {
        if( player.isDead )
        {
            currentScore.SetActive(false);
            UpdateHighScore();
            ScoreBoard.SetActive(true);
            restartButton.SetActive(true);
        }
        if (GameStarted)
        {
            StartGame();
        }
        Debug.Log(PlayerScore);
        ScoreText.text = PlayerScore.ToString();
    }

    public void StartGame()
    {
        currentScore.SetActive(true);
        PipeSpawner.SetActive(true);
        GetReady.SetActive(false);
        Tap.SetActive(false);
    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        GameStarted = false;
    }
    
    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);
    }

    public void UpScore()
    {
        PlayerScore++;
    }

    public void UpdateHighScore()
    {
        if (PlayerScore >= HighScore)
        {
            HighScore = PlayerScore;
            PlayerPrefs.SetInt("HighScore", getHighScore());
        }else if (PlayerScore > middleScore && PlayerScore < HighScore)
        {
            middleScore = PlayerScore;
            PlayerPrefs.SetInt("middleScore", middleScore);
        }
        else if(PlayerScore > lowScore && PlayerScore < middleScore)
        {
            lowScore = PlayerScore;
            PlayerPrefs.SetInt("lowScore", lowScore);
        }
    }

    public int getCurrentScore()
    {
        return PlayerScore;
    }
    public int getHighScore()
    {
        return HighScore;
    }

    public int getmiddleScore()
    {
        return middleScore;
    }

    public int getLowScore()
    {
        return lowScore;
    }
}

