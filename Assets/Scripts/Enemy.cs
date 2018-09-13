using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wayPointIndex = 0;

	// Use this for initialization
	void Start () {
        target = Waypoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
	}

    void GetNextWaypoint()
    {
        if(wayPointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
        }

        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }
}
