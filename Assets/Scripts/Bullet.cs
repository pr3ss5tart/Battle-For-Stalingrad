using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //target
    private Transform target;

    public float speed = 70f;

    public GameObject hitEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        //find direction of target
        Vector3 dir = target.position - transform.position;
        float distanceMPF = speed * Time.deltaTime; //Distance moved per frame

        if(dir.magnitude <= distanceMPF)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceMPF, Space.World);
	}

    void HitTarget()
    {
        GameObject hitEffectInstance = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(hitEffectInstance, 1.5f);

        Destroy(gameObject);
        Destroy(target.gameObject);
    }

    
}
