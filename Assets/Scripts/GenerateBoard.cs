using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GenerateBoard : MonoBehaviour {

    public GameObject obstacle;
    public GameObject trap;
    public GameObject russian;
    public GameObject german;
    public GameObject[] tilePrefabs;

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<Renderer>().bounds.size.x; }
    }

	// Use this for initialization
	void Start () {
        
       CreateLevel();
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void CreateLevel()
    {
        //string[] mapData = ReadLevelData();
        string[] mapData = new string[]
        {
            "2222222222222",
            "3000000000001",
            "2022222222222",
            "2022222220002",
            "3000000020201",
            "2022222000222",
            "2022222222222",
            "2022222222222",
            "3000000000001",
            "2222222222222"
        };

        int mapXSize = mapData[0].ToCharArray().Length; //since each index is the same length, we can just use one index as reference
        int mapYSize = mapData.Length;

        Vector3 worldStart = new Vector3(0, 0, 0);

        for (int y = 0; y < mapYSize; y++)
        {
            char[] newTiles = mapData[y].ToCharArray(); //stores the chars at index y in their own array
            for (int x = 0; x < mapXSize; x++)
            {
                //places tile in world
                //newTiles[x].ToString iterates through each char in newTiles array. NewTiles gets recreated with new indexes once this is done.
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }
    }

    private Vector3 PlaceTile(string tileType, int x, int z, Vector3 worldStart)
    {
        Debug.Log("Boop");

        //parses tile type to an int, so it can use it as an indexer when we create new tile
        int tileIndex = int.Parse(tileType);

        if (tileIndex == 3) //spawns russian player piece
        {
            GameObject newPiece = Instantiate(russian);
            newPiece.transform.position = new Vector3(TileSize * x, 0.5f, TileSize * z);
        }
        else if (tileIndex == 1) //spawns german piece
        {
            GameObject newPiece = Instantiate(german);
            newPiece.transform.position = new Vector3(TileSize * x, 0.5f, TileSize * z);
        }

        //Creates new tile and makes reference to that tile in newTile vars
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        //GameObject newTile = Instantiate(tilePrefabs[tileIndex]);

        //Uses mew tile var to change pos of tile
        newTile.transform.position = new Vector3(TileSize * x, 0, TileSize * z);

        //newTile.Setup(new Point(x, z));
        return newTile.transform.position;
    }

    //Trying to get ReadLevelData() to work...
    private string[] ReadLevelData()
    {
        Debug.Log("Reading level data...");
       
        string fileText = System.IO.File.ReadAllText(@"C:\Users\bloesch\Desktop\Battle-For-Stalingrad-master\Battle-For-Stalingrad-master\Assets\Level.txt");
        string[] textArr = fileText.Split('\n');

        for (int i = 0; i < textArr.Length*2; i++)
        {
            Debug.Log(textArr[i]);
        }

        return textArr;
    }
}
