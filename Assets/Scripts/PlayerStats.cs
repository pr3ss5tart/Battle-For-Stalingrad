using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int health;
    public int wallet = 5;
    public Text walletText;
    public Text healthText;

	// Use this for initialization
	void Start () {
        health = 5;
	}
	
	// Update is called once per frame
	void Update () {
        DisplayUI();

		if(health <= 0)
        {
            Debug.Log("Game over! You lose!!");
            SceneManager.LoadScene("GameOverScene");
        }
	}

    void DisplayUI()
    {
        //UI displays here
        healthText.text = "HEALTH: " + (health);
        walletText.text = "$ "+wallet;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            health--;
        }
    }
}
