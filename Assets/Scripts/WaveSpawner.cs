using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour {

    public Wave[] waves;
    public GameObject enemySpawner;
    public float timeBeforeWaves = 5.00f;
    public int waveNumber = 0;
    public float countdown = 2f;
    public static int enemiesAlive = 0;

    [Header("Spawner UI")]
    public Text countdownText;
    public Text waveText;

    //Stack<GameObject> enemies = new Stack<GameObject>();
    
    private GameObject cards;
    private CardSpawner cardSpawner;

    void Start()
    {
        cards = GameObject.Find("Hand");
        cardSpawner = cards.GetComponent<CardSpawner>();
    }

    // Update is called once per frame
    void Update () {

        DisplayUI();
            
            //This will stop spawns until all enemies are dead...
            if(enemiesAlive > 0)
            {
                return;
            }

        if (waveNumber == waves.Length)
        {
            //Debug.Log("Enemies Alive "+enemiesAlive);
            //if (enemiesAlive <= 0)
            //{
            Debug.Log("You Win!");
            SceneManager.LoadScene("WinScene");
            this.enabled = false;
            //}
        }

        if (countdown <= 0f) //runs countdown to next wave
            {
                //Debug.Log("Incoming wave...");
                cardSpawner.DrawCard();
                StartCoroutine("SpawnWaves");
                countdown = timeBeforeWaves;
                return;
            }
            countdown -= Time.deltaTime; 
        
    }

    void DisplayUI()
    {
        //UI displays here
        waveText.text = "Wave: " + (waveNumber);
        countdownText.text = string.Format("{0:00}", countdown);
    }

    //After instantiation, load enemy into enemyList. 
    IEnumerator SpawnWaves()
    {
        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count+3; i++)
        {          
            GameObject e = Instantiate(wave.enemy, enemySpawner.transform.position, enemySpawner.transform.rotation);
            enemiesAlive++;
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveNumber++;

        //Debug.Log("WaveNum " + waveNumber + " Waves.len "+waves.Length);

        

    }
}
