using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GenerateBoard : MonoBehaviour {

    public GameObject obstacle;
    public GameObject trap;
    public GameObject[] tilePrefabs;

	// Use this for initialization
	void Start () {
        
       CreateLevel();
    }
	
    //I'm a comment

	// Update is called once per frame
	void Update () {
		
	}

    private void CreateLevel()
    {
        //string[] mapData = ReadLevelData();
        string[] mapData = new string[]
        {
            "220222022220000000",
            "020202020020000000",
            "020202020020000000",
            "020202020020000000",
            "020202020020000000",
            "020202020020000000",
            "022202220022000000"
            //"000000000000000000"
        };

        int mapXSize = mapData[0].ToCharArray().Length; //since each index is the same length, we can just use one index as reference
        int mapYSize = mapData.Length; 

        for (int y = 0; y < mapYSize; y++)
        {
            char[] newTiles = mapData[y].ToCharArray(); //stores the chars at index y in their own array
            for (int x = 0; x < mapXSize; x++)
            {
                //newTiles[x].ToString iterates through each char in newTiles array. NewTiles gets recreated with new indexes once this is done.
                GenerateTile(newTiles[x].ToString(), x, y);
            }
        }
    }

    void GenerateTile(string tileType, int x, int y)
    {
        int tileIndex = int.Parse(tileType); //converts from string to int
        float tileX = tilePrefabs[0].GetComponent<Renderer>().bounds.size.x; //Gets size of tile

        switch (tileIndex)
        {
            case 0:
                GameObject newTile0 = Instantiate(tilePrefabs[tileIndex]);
                newTile0.transform.position = new Vector3(tileX * x, 0, tileX * y);
                break;
            case 1:
                GameObject newTile1 = Instantiate(tilePrefabs[tileIndex]);
                GameObject newPiece1 = Instantiate(trap);
                newTile1.transform.position = new Vector3(tileX * x, 0, tileX * y);
                newPiece1.transform.position = new Vector3(tileX * x, 0.5f, tileX * y);
                break;
            case 2:
                GameObject newTile2 = Instantiate(tilePrefabs[tileIndex]);
                GameObject newPiece2 = Instantiate(obstacle);
                newTile2.transform.position = new Vector3(tileX * x, 0, tileX * y);
                newPiece2.transform.position = new Vector3(tileX * x, 0.5f, tileX * y);
                break;
        }

    }

    private string[] ReadLevelData()
    {
        Debug.Log("Reading level data...");
       
        string fileText = System.IO.File.ReadAllText(@"C:\Users\bloesch\Desktop\Battle-For-Stalingrad-master\Battle-For-Stalingrad-master\Assets\Level.txt");
        string[] textArr = fileText.Split('\n');
        /* try
         {
             string tempData = data.text.Replace(Environment.NewLine, string.Empty); //loads data into temp string, also replaces '-' with ' '
             return tempData.Split('-');
         }
         catch(NullReferenceException ex)
         {
             Debug.Log(ex);
         }*/

        for (int i = 0; i < textArr.Length*2; i++)
        {
            Debug.Log(textArr[i]);
        }

        return textArr;
    }
}
