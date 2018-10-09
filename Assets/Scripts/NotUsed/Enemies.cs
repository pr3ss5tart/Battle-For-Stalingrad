using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public float speed = 10f;
    public GameObject enemySpawner;

    private GameObject target;
    private int waypointIndex = 0;

    GameObject[] waypointArray;

    private void Awake()
    {
        Debug.Log("I am alive!!!!!");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Fucking kill me...");

        //The problem is it's reading the text file line by line. Which throws off the waypoint array...
        //I really don't want to have to manually hand place the waypoints...But I might have to :/
        waypointArray = FindObjectOfType<BuildLevel>().waypoints.ToArray();

        target = waypointArray[0];
        Debug.Log("Waypoint array size: " + waypointArray.Length);

    }

    // Update is called once per frame
    void Update () {
        //places enemy at spawner
        //this.transform.position = new Vector3(enemySpawner.transform.position.x, 1, enemySpawner.transform.position.x);

         /*waypointArray = FindObjectOfType<BuildLevel>().waypoints.ToArray();

         target = waypointArray[0];
        Debug.Log("Waypoint array size: " + waypointArray.Length);
        */
        //move to current target
        Vector3 direction = target.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        //switch waypoints by checking id distance is 0
        if(Vector3.Distance(transform.position, target.transform.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        waypointIndex++;
        target = waypointArray[waypointIndex];
        Debug.Log("Next waypoint: " + target);
        if (waypointIndex >= waypointArray.Length -1)
        {
            Destroy(gameObject);
            print("Sweet release of death!");
        }
       
    }
}
