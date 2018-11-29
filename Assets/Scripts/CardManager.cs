using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    public GameObject go;
    private TowerBuilder towerBuilder;
    private Spells spellcaster;

    // Use this for initialization
    void Start () {
        go = GameObject.Find("CardBuilder");
        towerBuilder = go.GetComponent<TowerBuilder>();
        spellcaster = go.GetComponent<Spells>();
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
                spellcaster.isMolotov = true;
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
