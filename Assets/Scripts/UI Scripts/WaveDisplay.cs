﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

    public WaveSpawner ws;

    public Text waveText;

	// Update is called once per frame
	void Update() {
        waveText.text = "Wave: " + (ws.waveNumber - 1);
	}
}
