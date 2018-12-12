//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class TogglePannel : MonoBehaviour {

//    public GameObject menu;
//    public GameObject nextMenu;

//    public Text tutorialText;

//    public List<string> textList;
//    public int count;
//    public bool isPaused;

//    void Start()
//    {
//        count = 0;
//        tutorialText.text = textList[count];
//        On();
//    }

//	public void On()
//    {
//        menu.SetActive(true);
//        isPaused = true;

//        pause game
//        Time.timeScale = 0f;
//    }

//    public void Off()
//    {
//        menu.SetActive(false);
//        isPaused = false;
//        count++;
        
//        MoveText(textList[count]);

//        unpause game
//        Time.timeScale = 1f;
//    }

//    public void MoveText(string text)
//    {
//        string[] textData = text.Split(':');

//        tutorialText.text = textData[0];
//        int x = 0;
//        int.TryParse(textData[1], out x);
//        int y = 0;
//        int.TryParse(textData[2], out y);

//        //Move menu to new coords
//        //menu.RectTransform.localPosition += new Vector3(x, 0f, y);
//    }

//}
