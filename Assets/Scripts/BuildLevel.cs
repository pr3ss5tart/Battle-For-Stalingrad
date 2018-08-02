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
    private string[] mapData = new string[]{
            /*"2222222222222",
            "2222222222222",
            "2222222222222",
            "2222222224042",
            "1400000420203",
            "2222222404222",
            "2222222222222",
            "2222222222222",
            "2222222222222",
            "2222222222222"*/
            "2222221222222",
            "2222224222222",
            "2222220222222",
            "2222220222222",
            "2222220222222",
            "2222220222222",
            "2222244222222",
            "2222202222222",
            "2222240422222",
            "2222222322222"
    };

    public GameObject obstacle;
    public GameObject trap;
    public GameObject russian;
    public GameObject german;
    public GameObject waypoint;
    public GameObject[] tilePrefabs;
    public List<GameObject> waypoints = new List<GameObject>(); //sweet jebus I have too many waypoint things

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<Renderer>().bounds.size.x; }
    }

    private int itr = 0;
	// Use this for initialization
	void Start () {
        mapFile = new FileInfo("Level.txt"); //allows OpenText() to work in next line
        reader = mapFile.OpenText(); //opens mapFile for reading

        CreateLevel();
    }

    // Update is called once per frame
    void Update () {
       
    }

    private void CreateLevel()
    {

        int mapSizeX = mapData[0].ToCharArray().Length;
        int mapSizeY = mapData.Length;

        //places nodes at x,y coords
        for (int y = 0; y < mapSizeY; y++)
        {
            char[] newNodes = mapData[y].ToCharArray(); //E.g. newNodes[0] = 2,2,2...,2
            for(int x = 0; x < mapSizeX; x++)
            {
                PlaceNode(newNodes[x].ToString(), x, y);
            }
        }

        Debug.Log("Fucking waypoints!!!!!" + waypoints.Count);
       
    }

    //PlaceNode generates a new node, based on nodeType, x, y coords.
    private void PlaceNode(string nodeType, int x, int y)
    {

        int typeIndex = int.Parse(nodeType);

        //dealing with enemy waypoints
        if(typeIndex == 4)
        {
            GameObject waypointPiece = Instantiate(waypoint);
            waypointPiece.transform.position = new Vector3(TileSize * x, 2f, TileSize * y);
            waypoints.Add(waypointPiece);
            //Debug.Log("Waypoint Num: " + itr+" at X: "+waypointPiece.transform.position.x+" and Y: "+ waypointPiece.transform.position.z);
            //itr++;
        }

        if (typeIndex == 3)
        {
            GameObject endWaypoint = Instantiate(waypoint);
            endWaypoint.transform.position = new Vector3(TileSize * x, 2f, TileSize * y);
            waypoints.Add(endWaypoint);
            //Debug.Log("Waypoint Num: " + itr + " at X: " + endWaypoint.transform.position.x + " and Y: " + endWaypoint.transform.position.z);
            //itr++;
        }

        //creates new GameObject based off typeIndex
        GameObject newNode = Instantiate(tilePrefabs[typeIndex]);

        //Uses mew tile var to change pos of tile
        newNode.transform.position = new Vector3(TileSize * x, 0, TileSize * y);

    }

    //will come back to this...
    private void ReadLevelData()
    {
       
    }
}
