using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    //TODO
    /*
     1. When first called, check cardType
     2. void ShuffleDeck() this loads a number of cards into the deck. 
     3. Card DrawCard() Player draws one card per wave. Don't worry about resource points yet...*/


    //void CreateCard(string cardType, string cardName){
    /*This method holds a hastable of cardNames linked to cardData,
     which is separated by the two greater card type catagories: Spell or Tower*/
    //}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateCard(string cardName)
    {
        switch (cardName)
        {
            case "Molotov":
                Debug.Log("Molotov selected");
                break;
            case "Soldier":
                Debug.Log("Soldier selected");
                break;
            case "Sniper":
                Debug.Log("Sniper selected");
                break;
            default:
                Debug.Log("Invalid card type...");
                return;
        }
    }
}
