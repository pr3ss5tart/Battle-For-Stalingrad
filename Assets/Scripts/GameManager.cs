/*
 This class keeps track of WaveNumber, whether one player has won or lost, etc.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject waveSpawner;
    public GameObject towerBuilder;
    public PlayerStats playerStats;
    public int playerHealth;

    public bool isPaused;
    public bool isGameOver;

	// Use this for initialization
	void Start () {
        isGameOver = false;
        isPaused = false;
        playerHealth = playerStats.health;
	}
	
	// Update is called once per frame
	void Update () {

        if(isPaused == true)
        {
            towerBuilder.SetActive(false);
        }
        else
        {
            towerBuilder.SetActive(true);
        }

        if(isGameOver == true)
        {
            GameOver();
        }
	}

    void GameOver()
    {
        Debug.Log("You lose!");
        SceneManager.LoadScene("GameOverScene");
    }   
}
