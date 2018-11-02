using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {
        health = 5;
        Debug.Log("Player-Player health: " + health);
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Debug.Log("Game over! You lose!!");
            SceneManager.LoadScene("GameOverScene");
        }
	}
}
