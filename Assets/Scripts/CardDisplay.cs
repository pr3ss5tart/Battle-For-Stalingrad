using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Text descriptionText;

    public Text healthText;
    public Text resourceText;
    public Text attackText;

	// Use this for initialization
	void Start () {
        nameText.text = card.name;
        descriptionText.text = card.description;
        healthText.text = card.health.ToString();
        resourceText.text = card.resourceCost.ToString();
        attackText.text = card.attack.ToString();
	}
	
}
