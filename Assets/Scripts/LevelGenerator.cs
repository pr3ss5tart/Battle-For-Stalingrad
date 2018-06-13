using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class LevelGenerator : MonoBehaviour {

    public Transform russians;
    public Transform germans;
    public Transform floor_valid;
    public Transform floor_obstacle;
    //public Transform floor_trap;

    public const string sfloor_valid = ".";
    public const string sfloor_obstacle = "#";
    public const string sgermans = "G";
    public const string srussians = "R";

	// Use this for initialization
	void Start () {
        string[][] map = ReadFile("C:/Users/bloesch/Desktop/Battle For Stalingrad/Assets/BfS_TestLvl.txt");

        //create level based on map
        for(int y = 0; y < map.Length; y++)
        {
            Debug.Log("Map[" + y + "]");
            for (int x = 0; x < map.Length+1; x++)
            {
                Debug.Log("Map[" + y + "][" + x + "]");
                switch (map[y][x])
                {
                    case srussians:
                        Instantiate(floor_valid, new Vector3(x, 0, -y), Quaternion.identity); //Why do we have Quaternion.identity?
                        Instantiate(russians, new Vector3(0, 0.5f, 0), Quaternion.identity);
                        break;
                    case sgermans:
                        Instantiate(floor_valid, new Vector3(x, 0, -y), Quaternion.identity); //Why do we have Quaternion.identity?
                        Instantiate(germans, new Vector3(0, 0.5f, 0), Quaternion.identity);
                        break;
                    case sfloor_valid:
                        Instantiate(floor_valid, new Vector3(x, 0, -y), Quaternion.identity); //Why do we have Quaternion.identity?
                        break;
                    case sfloor_obstacle:
                        Instantiate(floor_obstacle, new Vector3(x, 0, -y), Quaternion.identity); //Why do we have Quaternion.identity?
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    string[][] ReadFile(string file)
    {
        string text = System.IO.File.ReadAllText(file);
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;

        string[][] levelBase = new string[rows][];
        for(int i = 0; i < lines.Length; i++)
        {
            string[] lineStrings = Regex.Split(lines[i], " ");
            levelBase[i] = lineStrings;
        }
        Debug.Log("File Read");
        return levelBase;
    }

    void GenerateLevel()
    {

    }
}
