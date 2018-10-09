using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour {

    public GameObject tower;

    //Once clicked, this node will spawn a Tower. 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log(this.gameObject.transform.position);
        Instantiate(tower);
        tower.transform.position = this.transform.position;
    }
}
