/*
 This class keeps track of WaveNumber, whether one player has won or lost, etc.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject waveSpawner;
    //public GameObject towerBuilder;
    //public PlayerStats playerStats;
    // public int playerHealth;

    public bool isPaused;
    public bool isGameWon;
    public bool isGameOver;

    public GameObject ws_go;
    private WaveSpawner ws;

    // Use this for initialization
    void Start()
    {
        ws_go = GameObject.Find("WaveSpawner");
        ws = ws_go.GetComponent<WaveSpawner>();

        isGameOver = false;
        isPaused = false;
        isGameWon = false;
        //playerHealth = playerStats.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(ws.waveNumber >= 4)
        {
            isGameWon = true;
        }

        //if (isPaused == true)
        //{
        //    towerBuilder.SetActive(false);
        //}
        //else
        //{
        //    towerBuilder.SetActive(true);
        //}

        if (isGameOver == true)
        {
            GameOver();
        }

        if(isGameWon == true)
        {
            Winning();
        }
    }

    void GameOver()
    {
        Debug.Log("You lose!");
        SceneManager.LoadScene("GameOverScene");
    }

    void Winning()
    {
        Debug.Log("You win!");
        SceneManager.LoadScene("WinScene");
    }
}
