using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Spell")]
public class Spell : ScriptableObject {

    public string cardName;
    public string description;

    public int resourceCost;

    // Use this for initialization
    void Start () {
        Debug.Log(cardName + " " + resourceCost + " " + description);
    }
	
	// Update is called once per frame
	void Update () {
		if(this.cardName == "Molotov")
        {
            Debug.Log("Molotov out!!!");
        }
	}
}
