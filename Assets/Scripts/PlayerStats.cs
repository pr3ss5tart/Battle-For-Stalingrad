using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public int health;
    public GameObject healthBar;

	// Use this for initialization
	void Start () {
        health = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Debug.Log("Game over! You lose!!");
            SceneManager.LoadScene("GameOverScene");
        }
	}

    public void Damage()
    {
        healthBar.transform.localScale -= new Vector3(.5f, 0, 0);
        health--;
        Debug.Log("Player-Player health: " + health);
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log("Boop!");
    //    if (col.collider.tag == "Enemy")
    //    {
    //        Damage();
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Boop!");
        if (col.tag == "Enemy")
        {
            Damage();
        }
    }
}
