using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {

    public List<GameObject> cardsToBeInserted;

    //List of cards, randomly placed in deck
    public List<GameObject> cardDeck;

    private int count = 0;

    private GameObject go;

    List<GameObject> ShuffleDeck(List<GameObject> emptyList)
    {
        List<GameObject> deck = emptyList;

        //Random r = new Random();

        for(int i = 0; i < 30; i++)
        {
            //generate rand num from 0 - deck.Count-1
            int index = Random.Range(0, deck.Count);

            cardDeck.Add(deck[index]);

            //Debug.Log("Card added: " + cardDeck[i]);

        }

        return deck;
    }

    public void DrawCard()
    {
        GameObject go = (GameObject)Instantiate(cardDeck[0], this.transform.position, this.transform.rotation);
        go.transform.SetParent(this.transform);
        cardDeck.Remove(cardDeck[0]);
        Debug.Log("Card drawn");
    }

	// Use this for initialization
	void Start () {
        ShuffleDeck(cardsToBeInserted);

        //init hand
        for (count = 0; count < 3; count++)
        {
            go = (GameObject)Instantiate(cardDeck[count], this.transform.position, this.transform.rotation);
            go.transform.SetParent(this.transform);
            cardDeck.Remove(cardDeck[count]);
        }

        Debug.Log("Cards left in deck: " + cardDeck.Count);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
