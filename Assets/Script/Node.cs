using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject currentTurret;

    [ColorUsage(true, true)]
    public Color hoverColor;
    [ColorUsage(true, true)]
    public Color noMoneyColor;
    [ColorUsage(true, true)]
    private Color startColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponentInChildren<Renderer>(false);
        startColor = rend.material.GetColor("_EmissiveColor");
    }

    private void OnMouseDown() {
        if(currentTurret != null)
        {
            MainGameController.instance.nodeUi.ShowNodeUi(this);
            return;
        }
        MainGameController.instance.nodeUi.HideNodeUi();

        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }
        if(BuildManager.instance.GetTurretToBuild().price > MainGameController.instance.gold)
        {
            return;
        }
        currentTurret = Instantiate(BuildManager.instance.GetTurretToBuild().pref,transform.position,Quaternion.identity);
        MainGameController.instance.gold -= BuildManager.instance.GetTurretToBuild().price;
        BuildManager.instance.ClearTurretToBuild();


    }

    private void OnMouseEnter()
    {
        if (BuildManager.instance.GetTurretToBuild() != null && BuildManager.instance.GetTurretToBuild().price > MainGameController.instance.gold)
        {
            rend.material.SetColor("_EmissiveColor", noMoneyColor);
        }
        else
        {
            rend.material.SetColor("_EmissiveColor", hoverColor);
        }

        
         
    }

    private void OnMouseExit()
    {
        rend.material.SetColor("_EmissiveColor", startColor);
    }
}
