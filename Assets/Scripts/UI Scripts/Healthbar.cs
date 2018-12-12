using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {

    Vector3 localScale;

	// Use this for initialization
	void Start () {
        localScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        if(this.tag == "Enemy")
        {
            Debug.Log("Enemy HealthBar");
            localScale.x = Enemy.enemyHealth;
            transform.localScale = localScale;
        }else if(this.tag == "Tower")
        {
            Debug.Log("Tower HealthBar");
            localScale.x = Tower.towerHealth;
            transform.localScale = localScale;
        }
        
	}
}
