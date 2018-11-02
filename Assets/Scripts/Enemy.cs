using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public bool isTurnCoat;
    public string towerTag = "Tower";
    public string enemyTag = "Enemy";
    public float range = 10f;
    public Transform firepoint;
    public Transform partToRotate;
    public GameObject bulletPrefab;

    private int enemyHealth = 10;
    private float fireCountdown = 0f;
    private float fireRate = 1f;
    private float gunTurnSpeed = 10f;
    private Transform target;
    private Transform enemyTarget;
    private int wayPointIndex = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("Enemy health " + enemyHealth);
        target = Waypoints.points[0];
        enemyTarget = null;
        isTurnCoat = false;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update () {
        //Vector3 dir = target.position - transform.position;
        //transform.Translate(dir.normalized * speed * Time.deltaTime);

        //if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        //{
        //    GetNextWaypoint();
        //}

        StartCoroutine(Move());

        AimAtEnemy();
        //UpdateTarget();

        
    }

    void AimAtEnemy()
    {
        if (enemyTarget == null) //this forces update to not run unless target is spotted
            return;

        ////Here we turn our turret
        Vector3 dir = enemyTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Smoothly move from current rotation to lookRotation, over time multiplied by gunTurnSpeed
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * gunTurnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Debug.Log("BANG BANG!");
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime; //Decreases countdown by each second
    }

    void Shoot()
    {
        
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation); //Casts GameObj to bullet instantiation
        EnemyBullet enemyBullet = bulletGO.GetComponent<EnemyBullet>();

        if (enemyBullet != null)
        {
            //bullet.SetDmg(towerAttack);
            enemyBullet.Seek(enemyTarget);
        }
    }

    //Enemy Move
    IEnumerator Move()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        yield return null;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("Enemy health "+enemyHealth);
        if (enemyHealth <= 0)
            Destroy(gameObject); //kill enemy
    }

    void GetNextWaypoint()
    {
        if(wayPointIndex >= Waypoints.points.Length - 1) //reaches end of waypoints
        {
            Destroy(gameObject);
        }

        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    void UpdateTarget()
    {
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        //We need an array to list the number of Towers in the map.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(towerTag);

        /*if(isTurnCoat == true)
        {
            //We need an array to list the number of Towers in the map.
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(towerTag);
        }
        else
        {
            //We need an array to list the number of Enemy in the map.
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        }*/


        foreach (GameObject enemy in enemies)
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
                enemyTarget = closestEnemy.transform;
                Debug.Log("Surprise Mothafucka!");
            }
            else
            {
                enemyTarget = null;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
