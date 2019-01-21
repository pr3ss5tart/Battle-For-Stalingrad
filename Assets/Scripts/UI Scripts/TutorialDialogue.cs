using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour {

    public Text tutorialText;
    //public GameObject upArrow;
    //public GameObject downArrow;
    public List<string> strList;
    public static Transform[] positions;

    private int count = 0;
    private GameObject upArrow;
    private GameObject downArrow;

    private void Awake()
    {
        //Here we go about getting the transforms of where we want to place the tutorial arrows...
        GameObject go = GameObject.Find("ArrowPositions"); //Finds obj containing transforms of ArrowPositions
        positions = new Transform[go.transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = go.transform.GetChild(i); //loads the transforms from ArrowPositions into positions
        }

        Debug.Log("Number of transforms within positions: " + positions.Length);
    }

    // Use this for initialization
    void Start () {
        tutorialText.text = strList[count];
        Time.timeScale = 0f;

        upArrow = GameObject.Find("Up");
        downArrow = GameObject.Find("Down");

        upArrow.SetActive(false);
        downArrow.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextText()
    {
        if(count < strList.Count)
        {
            count++;
            MoveArrow(positions);
            tutorialText.text = strList[count];
        }
    }

    public void BackText()
    {
        if(count > 0)
        {
            count--;
            MoveArrow(positions);
            tutorialText.text = strList[count];
        }
    }

    void MoveArrow(Transform[] positions)
    {
        if(count % 2 == 0) //current tutorial box index is odd
        {
            //activate downArrow, deactive upArrow
            downArrow.SetActive(true);
            upArrow.SetActive(false);

            //place down arrow at positions[count]
            downArrow.transform.position = positions[count].position;
        }else if(count % 2 == 1) //current tutorial box index is even
        {
            //activate upArrow, deactive downArrow
            downArrow.SetActive(false);
            upArrow.SetActive(true);

            //place down arrow at positions[count]
            upArrow.transform.position = positions[count].position;
        }
        else
        {
            Debug.LogError("Unknown arrow position!");
        }
    }
}
