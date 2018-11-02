using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour {

    public GameObject sniper;

    public bool canBuild = false;

    public Vector3 nodePos;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void GetNodePos()
    {

    }

    public void CreateTower()
    {
        if(canBuild == false)
        {
            return;
        }
        else
        {

        }
    }
}
