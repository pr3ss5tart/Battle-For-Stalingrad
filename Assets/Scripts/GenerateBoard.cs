using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard : MonoBehaviour {

    public GameObject walkable;

	// Use this for initialization
	void Start () {
        string[] mapData = { "44444", "11111", "33333", "22222" };
        MapGenerator();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MapGenerator()
    {
        float tileX = walkable.GetComponent<Renderer>().bounds.size.x;
        float tileY = walkable.GetComponent<Renderer>().bounds.size.y;

        for (int y = 0; y < 5; y++)
        {
            for(int x = 0; x < 5; x++)
            {
               GameObject newTile = Instantiate(walkable);
                newTile.transform.position = new Vector3(tileX * x, 0, tileX*y);
            }
        }
    }
}
