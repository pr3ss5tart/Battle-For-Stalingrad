using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject standardTurretprefab;
    public GameObject missleTowerPrefab;


    //private TurretBlueprint turretToBuild;
    private GameObject turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    //public bool CanBuild { get { return turretToBuild != null; } }

    void Awake()
    {
        //Singleton Pattern
        if(instance != null)
        {
            Debug.LogError("Another instance of BuildManager exists!");
            return;
        }

        //GameObject turretToBuild = BuildManager.instance.Ge
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

    //public void SelectedNode(Node node)
    //{
    //    if(selectedNode == node)
    //    {
    //        DeselectNode();
    //        return;
    //    }

    //    selectedNode = node;
    //    turretToBuild = null;

    //    nodeUI.SetTarget(node);
    //}

    //public void DeselectNode()
    //{
    //    selectedNode = null;
    //    //nodeUI.Hide();
    //}

    //public void SelectTurretToBuild(TurretBlueprint turret)
    //{
    //    turretToBuild = turret;
    //    DeselectNode();
    //}

    //public TurretBlueprint GetTurretToBuild()
    //{
    //    return turretToBuild;
    //}


}
