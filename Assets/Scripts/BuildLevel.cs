/*This script we want to do a few things:
 1. Read a number of map-strings
 2. Places nodes according to where they are in strings
 3. Creates linked lists containing nodes within walkable paths
 ...
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BuildLevel : MonoBehaviour {

    protected FileInfo mapFile = null;
    protected StreamReader reader = null;
    protected string text = " ";
    public string[] mapData = new string[]{
            "2222222222222",
            "0000000000002",
            "2022222222222",
            "2022222220002",
            "3000000020201",
            "2022222000222",
            "2022222222222",
            "2022222222222",
            "0000000000002",
            "2222222222222"
    };

    public GameObject obstacle;
    public GameObject trap;
    public GameObject russian;
    public GameObject german;
    public GameObject[] tilePrefabs;

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<Renderer>().bounds.size.x; }
    }

    private int itr = 0;
	// Use this for initialization
	void Start () {
        mapFile = new FileInfo("Level.txt"); //allows OpenText() to work in next line
        reader = mapFile.OpenText(); //opens mapFile for reading
	}
	
	// Update is called once per frame
	void Update () {
        CreateLevel();
    }

    private void CreateLevel()
    {

        int mapSizeX = mapData[0].ToCharArray().Length;
        int mapSizeY = mapData.Length;
        
        //places nodes at x,y coords
        for(int y = 0; y < mapSizeY; y++)
        {
            char[] newNodes = mapData[y].ToCharArray(); //E.g. newNodes[0] = 2,2,2...,2
            for(int x = 0; x < mapSizeX; x++)
            {
                PlaceNode(newNodes[x].ToString(), x, y);
            }
        }
       
    }

    //PlaceNode generates a new node, based on nodeType, x, y coords.
    private void PlaceNode(string nodeType, int x, int y)
    {
        int typeIndex = int.Parse(nodeType);

        //creates new GameObject based off typeIndex
        GameObject newNode = Instantiate(tilePrefabs[typeIndex]);

        //Uses mew tile var to change pos of tile
        newNode.transform.position = new Vector3(TileSize * x, 0, TileSize * y);

        if (typeIndex == 3) //spawns russian player piece
        {
            GameObject newPiece = Instantiate(russian);
            newPiece.transform.position = new Vector3(TileSize * x, 0.5f, TileSize * y);
        }
        else if (typeIndex == 1) //spawns german piece
        {
            GameObject newPiece = Instantiate(german);
            newPiece.transform.position = new Vector3(TileSize * x, 0.5f, TileSize * y);
        }
    }

    //will come back to this...
    private void ReadLevelData()
    {
       
    }
}
