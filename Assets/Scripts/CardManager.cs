using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    public GameObject tb;
    private TowerBuilder towerBuilder;

    // Use this for initialization
    void Start () {
        //buildManager = buildManager.instance;
        //buildManager.CanBuild = false;
        //GameObject go = GameObject.FindGameObjectWithTag("Node");
        //node = go.GetComponent<Node>();
        tb = GameObject.Find("CardBuilder");
        towerBuilder = tb.GetComponent<TowerBuilder>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateCard(string cardName)
    {
        switch (cardName)
        {
            case "Molotov(Clone)":                  //Molotov
                Debug.Log("Molotov selected");
                break;
            case "TurnCoat(Clone)":                 //TurnCoat
                Debug.Log("Turn Coat selected");
                break;
            case "Flooding(Clone)":                 //Flood
                Debug.Log("Flooding selected");
                break;
            case "Soldier(Clone)":                  //Soldier
                Debug.Log("Soldier selected");
                towerBuilder.tower = towerBuilder.towerList[0];
                towerBuilder.canBuild = true;
                break;
            case "Sniper(Clone)":                   //Sniper
                Debug.Log("Sniper selected");      
                towerBuilder.tower = towerBuilder.towerList[1];
                towerBuilder.canBuild = true;
                break;
            case "Rocketeer(Clone)":                //Rocketeer
                Debug.Log("Rocketeer selected");        
                towerBuilder.tower = towerBuilder.towerList[2];
                towerBuilder.canBuild = true;
                break;
            default:
                Debug.Log("Invalid card type...");
                return;
        }
    }
}
