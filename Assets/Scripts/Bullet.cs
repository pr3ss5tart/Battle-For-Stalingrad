using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 70f;
    public GameObject hitEffect;
    public float areaOfEffect = 0f;

    private Transform target;
    private int damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void SetDmg(int dmg)
    {
        damage = dmg;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //find direction of target
        Vector3 dir = target.position - transform.position;
        float distanceMPF = speed * Time.deltaTime; //Distance moved per frame

        if (dir.magnitude <= distanceMPF)
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

        if (areaOfEffect > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Damage(target);
        //Destroy(gameObject);
    }

    void Explode()
    {
        //Damages each enemy within the blast radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, areaOfEffect);
        foreach(Collider col in colliders)
        {
            if(col.tag == "Enemy")
            {
                Debug.Log("Enemy hit!");
                Damage(col.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        Destroy(gameObject);
        //Destroy(enemy.gameObject);
        e.TakeDamage(1);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }


}
