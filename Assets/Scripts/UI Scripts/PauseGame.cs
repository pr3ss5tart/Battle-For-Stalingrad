using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {

    public GameObject pauseMenu;
    //public GameManager gameManager;
    public Node node;
    public bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }

    public void ContinueGame()
    {
        Debug.Log("Game continues!");
        //gameManager.isPaused = false;
        node.cantBuild = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        //gameManager.isPaused = true;
        node.cantBuild = true;
        Time.timeScale = 0f;
    }
}
