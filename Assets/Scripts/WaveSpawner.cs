using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject enemySpawner;
    public float timeBeforeWaves = 5.00f;
    public int waveNumber = 0;
    public float countdown = 2f;

    [Header("Spawner UI")]
    public Text countdownText;
    public Text waveText;

    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> enemiesToAdd = new List<GameObject>(); //temp enemies list

    void Start()
    {
        //Initial instantiation
    }

    // Update is called once per frame
    void Update () {

        DisplayUI();

        if (enemies.Count <= 0)
        {
            if(countdown <= 0f) //runs countdown to next wave
            {
                Debug.Log("Incoming wave...");
                StartCoroutine("SpawnWaves");
                countdown = timeBeforeWaves;
            }
            countdown -= Time.deltaTime;
        }
        else
        {
            RemoveEnemies();
        }

       
        
    }

    void DisplayUI()
    {
        //UI displays here
        waveText.text = "Wave: " + (waveNumber-1);
        countdownText.text = string.Format("{0:00}", countdown);
    }

    void RemoveEnemies()
    {
        int deadEnemies = 0;
        //continuously loop through enemies, checking to see if any are destroyed. If so, remove.
        foreach (GameObject e in enemies)
        {
            if (e == null)
            {
                //enemies.Remove(e);
                deadEnemies++;
            }

            //if all enemy in enemies are dead, clear list.
            if(deadEnemies == enemies.Count)
            {
                enemies.Clear();
            }
        }
    }

    //After instantiation, load enemy into enemyList. 
    IEnumerator SpawnWaves()
    {
        //List<GameObject> enemies = new List<GameObject>();

        for (int i = 0; i < waveNumber; i++)
        {
            GameObject e = Instantiate(enemyPrefab, enemySpawner.transform.position, enemySpawner.transform.rotation);

            enemies.Add(e);
            //Debug.Log("Enemy instantiated");
            yield return new WaitForSeconds(1f);
        }

        waveNumber++;
    }
}
