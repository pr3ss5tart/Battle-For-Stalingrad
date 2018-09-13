using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    //public static GameObject[] points;
    public static Transform[] points;

    int waypointCount;
    BuildLevel waypointsList;
    private void Start()
    {
        waypointCount = FindObjectOfType<BuildLevel>().waypoints.Count;
    }

    private void Awake()
    {
        /* Debug.Log("# of waypoints: " + waypointCount);
         points = new GameObject[waypointCount];
         GameObject[] waypointArray = waypointsList.waypoints.ToArray();

         foreach (GameObject g in waypointArray)
         {
             print("waypoint");
         }

         for (int i = 0; i < points.Length; i++)
         {
             points[i] = waypointArray[i];
         }*/

        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
