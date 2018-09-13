using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject {

    public string cardName;
    public string description;

    public int resourceCost;
    public int health;
    public int attack;
	
}
