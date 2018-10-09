using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject enemySpawner;
    public float timeBeforeWaves = 5f;
    public int waveNumber = 1;

    private float countdown = 2f;

    List<GameObject> enemies = new List<GameObject>();
    private bool isGameOver = false;

    // Update is called once per frame
    void Update () {

        //while(enemies != null){ SpawnWaves}
        while (!isGameOver)
        {
            while (enemies.Count > 0)
            {
                Debug.Log("Incoming wave...");
                StartCoroutine("SpawnWaves");
            }
        }
       

		/*if(countdown <= 0f)
        {
            //Debug.Log("Incoming wave...");
            StartCoroutine("SpawnWaves");
            countdown = timeBeforeWaves;
        }

        countdown -= Time.deltaTime;
        */
	}

    //After instantiation, load enemy into enemyList. 
    IEnumerator SpawnWaves()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            GameObject e = Instantiate(enemyPrefab, enemySpawner.transform.position, enemySpawner.transform.rotation);

            enemies.Add(e);
            Debug.Log("Enemy instantiated");
            yield return new WaitForSeconds(1f);
        }

        waveNumber++;
    }
}
