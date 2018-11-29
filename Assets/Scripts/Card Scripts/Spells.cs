using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spells : MonoBehaviour {

    public GameObject molotovHitEffect;
    public bool isMolotov;
    public float areaOfEffect = 0f;
    // Use this for initialization
    void Start () {
        isMolotov = false;
	}
	
	// Update is called once per frame
	void Update () {

        //check to see if path clicked && isMolotov == true
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //molotov
                if ((hit.transform.tag == "Path") && (isMolotov == true))
                {
                    Debug.Log("Molotov out!");
                    Molotov(hit.point);
                    isMolotov = false;
                }
                else
                {
                    Debug.Log("Spell unable to be used...");
                }

                //turncoat

            }
                
        }
    }

    //Orange particle effect appears on cursor.
    //Once player hovers over path, an semi-transparent, orange AOE appears
    //Wherever player clicks on path, a damaging sphere is created
    void Molotov(Vector3 clickPos)
    {
        GameObject hitEffectInstance = (GameObject)Instantiate(molotovHitEffect, clickPos, transform.rotation);
        Destroy(hitEffectInstance, 1.5f);

        areaOfEffect = 10f;
        Collider[] colliders = Physics.OverlapSphere(clickPos, areaOfEffect);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("BOOM!");
                SpellDamage(col.transform);
            }
        }
    }

    //Instantiates explosion at pos of enemy selected
    void TurnCoat()
    {

    }

    //sets speed of all enemies to 7 for 1 round
    void Flood()
    {

    }

    void SpellDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        Destroy(gameObject);
        e.TakeDamage(5);
    }
}
