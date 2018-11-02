using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TowerBuilder))]
public class Node : MonoBehaviour {

    public Color hoverColor;
    public GameObject turret;

    public Vector3 posOffset;
    public bool cantBuild = true;
    //public int canBuild = 0;

    private Renderer render;
    private Color startColor;

    BuildManager buildManager;

    public GameObject tb;
    private TowerBuilder towerBuilder;

    public bool canTBBuild = false;

    void Start()
    {
        cantBuild = false;
        render = GetComponent<Renderer>();
        startColor = render.material.color;
        //buildManager = BuildManager.instance;
        tb = GameObject.Find("CardBuilder");
        towerBuilder = tb.GetComponent<TowerBuilder>();   
    }

    //public Vector3 GetBuildPosition()
    //{
    //    return transform.position + posOffset;
    //}

    void OnMouseDown()
    {
        //Build turret
        if (towerBuilder.canBuild == false)
        {
            Debug.Log("Unable to build!");
            return;
        }
        else
        {
            Debug.Log("Woot, you can build!!!");
            //GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(towerBuilder.sniper, transform.position + posOffset, transform.rotation);
            towerBuilder.canBuild = false;
        }

    }

    //void BuildTurret(TurretBlueprint blueprint)
    //{
    //    //include resource points stuff here...

    //    //Build turret here...
    //    GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
    //    turret = _turret;

    //    Debug.Log("Turret built!");
    //}

    //public void UpgradeTurret()
    //{

    //}

    //public void SellTurret()
    //{

    //}

    void OnMouseEnter()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        //if (!buildManager.CanBuild)
        //    return;

        GetComponent<Renderer>().material.color = hoverColor;
    }

    void OnMouseExit()
    {
        render.material.color = startColor;
    }
}
