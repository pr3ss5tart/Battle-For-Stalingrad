using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public Color hoverColor;

    private Renderer render;
    private Color startColor;

    void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

	void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hoverColor;
    }

    void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
