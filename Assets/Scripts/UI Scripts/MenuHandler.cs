using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This script is mainly used for showing different menus.
public class MenuHandler : MonoBehaviour {

    //Game Menu States
    public enum MenuStates {Main, Options, Credits, Pause, Play};
    public MenuStates currentState;

    //Menu Panels
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject pauseMenu;
    public GameObject playMenu;
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case MenuStates.Main:
                //turn on main menu panel
                mainMenu.SetActive(true);
                //turn off all other panels
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                pauseMenu.SetActive(false);
                playMenu.SetActive(false);
                break;
            case MenuStates.Options:
                //turn on options panel
                optionsMenu.SetActive(true);
                //turn off all other panels
                mainMenu.SetActive(false);
                creditsMenu.SetActive(false);
                pauseMenu.SetActive(false);
                playMenu.SetActive(false);
                break;
            case MenuStates.Credits:
                //turn on credits panel
                creditsMenu.SetActive(true);
                //turn off all other panels
                optionsMenu.SetActive(false);
                mainMenu.SetActive(false);
                pauseMenu.SetActive(false);
                playMenu.SetActive(false);
                break;
            case MenuStates.Pause:
                //turn on pause panel
                pauseMenu.SetActive(true);
                //turn off all other panels
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                mainMenu.SetActive(false);
                playMenu.SetActive(false);
                break;
            case MenuStates.Play:
                //turn on play panel
                playMenu.SetActive(true);
                //turn off all other panels
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                pauseMenu.SetActive(false);
                mainMenu.SetActive(false);
                break;
            default:
                Debug.Log("Invalid menu state detected...");
                return;
        }
	}

    public void OnMainMenu() {
        Debug.Log("Main menu selected");
        currentState = MenuStates.Main;
    }

    public void OnOptionsMenu() {
        Debug.Log("Options menu selected");
        currentState = MenuStates.Options;
    }

    public void OnCreditsMenu() {
        Debug.Log("Credits menu selected");
        currentState = MenuStates.Credits;
    }

    public void OnPauseMenu() {
        Debug.Log("Pause menu selected");
        currentState = MenuStates.Pause;
    }

    public void OnPlayMenu() {
        Debug.Log("Play menu selected");
        currentState = MenuStates.Play;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
