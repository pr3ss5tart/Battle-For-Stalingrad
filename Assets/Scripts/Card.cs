using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Tower")]
public class Card : ScriptableObject {

    public string cardType;
    public string cardName;
    public string description;

    public int resourceCost;
    public int health;
    public int attack;
    public int effector;

    private bool effectActive = false;

    /*void Update()
    {
        //Here we possibly put effect?
        if(effectActive)
        Debug.Log("Blerp!");
    }*/

    public void Print()
    {
        Debug.Log(cardName + " " + cardType + " " + description + " " + attack);
    }
	
}
