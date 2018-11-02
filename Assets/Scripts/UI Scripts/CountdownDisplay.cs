using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownDisplay : MonoBehaviour {

    public WaveSpawner ws;
    public Text countdownText;
	
	// Update is called once per frame
	void Update () {
        countdownText.text = string.Format("{0:00.00}", ws.countdown);
	}
}
