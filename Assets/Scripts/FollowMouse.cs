//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FollowMouse : MonoBehaviour {

//    public float distance = 1f;
//    public bool useCameraDistance = false;

//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
//        float actualDistance;
//		if(useCameraDistance == true)
//        {
//            float actualDistance = (transform.position - Camera.main.transform.position).magnitude;
//        }
//        else
//        {
//            actualDistance = distance;
//        }
//        Vector3 mousePosition = Input.mousePosition;
//        mousePosition.z = distance;
//        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
//	}
//}
