﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    //Tower shoots at enemy mobs when in range.
    //They are destroyed if they sustain enough damage.

    //All tower cards inherit from the main tower class.

    [Header("Health")]
    public static float towerHealth = 20;

    [Header("Attack Variables")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f;
    public int towerAttack;
    public Transform firepoint;
    public GameObject bulletPrefab;

    [Header("Target Variables")]
    public Transform target;
    public string enemyTag = "Enemy";

    [Header("Unity Stuff")]
    public GameObject healthBar;

    // Use this for initialization
    void Start () {
        //This calls the UpdateTarget twice/sec. 
        //We want this so the turret will constantly scan for enemies.
        InvokeRepeating("UpdateTarget", 0f, 0.5f); 	
	}

    void UpdateTarget()
    {
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        //We need an array to list the number of enemies in the map.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
       
        foreach(GameObject enemy in enemies)
        {
            //We need to calculate the distance between this position and target position
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //Then we check to see if any enemies from enemyArr are within range of turret.
            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                closestEnemy = enemy;
            }

            //enemy within range
            if (closestEnemy != null && minDistance <= range)
            {
                target = closestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (target == null) //this forces update to not run unless target is spotted
            return;

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime; //Decreases countdown by each second
	}

    public void TakeDamage(int damage)
    {
        towerHealth -= damage;
        healthBar.transform.localScale -= new Vector3(0.5f, 0, 0);

        Debug.Log("Tower health " + towerHealth);
        if (towerHealth <= 0)
            Destroy(gameObject); //kill enemy
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation); //Casts GameObj to bullet instantiation
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetDmg(towerAttack);
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
