using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePannel : MonoBehaviour {

	public void Toggle(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
