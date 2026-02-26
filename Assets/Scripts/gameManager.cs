using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    [Header("DEPENDENCIES")]
    public GameObject startButton;
    public GameObject restartButton;
    public Player player;
    public GameObject ScoreBoard;
    
    private int PlayerScore;
    private int HighScore = 0;

    void Start()
    {
        ScoreBoard.SetActive(false);
        startButton.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if( player.isDead )
        {
            UpdateHighScore();
            ScoreBoard.SetActive(true);
            restartButton.SetActive(true);
        }
        
        Debug.Log(PlayerScore);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
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
        if (PlayerScore > HighScore)
        {
            HighScore = PlayerScore;
        }
    }

    void Init()
    {
        HighScore = getHighScore();
    }

    public int getCurrentScore()
    {
        return PlayerScore;
    }

    public int getHighScore()
    {
        return HighScore;
    }
}

