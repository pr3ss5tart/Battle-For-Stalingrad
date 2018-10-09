using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject standardTurretprefab;

    private GameObject turretToBuild;

    void Awake()
    {
        //Singleton Pattern
        if(instance != null)
        {
            Debug.LogError("Another instance of BuildManager exists!");
            return;
        }

        instance = this;
    }

    void Start()
    {
        turretToBuild = standardTurretprefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
