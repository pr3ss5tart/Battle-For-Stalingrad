using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject enemySpawner;

	// Use this for initialization
	void Start () {
        Debug.Log("spawning...");
        GameObject enemy = Instantiate(enemyPrefab);
        Debug.Log("spawning...");
        System.Threading.Thread.Sleep(1000); //wait for one sec
        GameObject enemy2 = Instantiate(enemyPrefab);
        Debug.Log("spawning...");
        System.Threading.Thread.Sleep(1000); //wait for one sec
        GameObject enemy3 = Instantiate(enemyPrefab);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
