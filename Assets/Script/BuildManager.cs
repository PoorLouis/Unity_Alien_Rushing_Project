using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public turretBluePrint basicTurretLV1Blueprint;
    public turretBluePrint basicTurretLV2Blueprint;
    public turretBluePrint basicTurretLV3Blueprint;
    public turretBluePrint LucherTurretLV1Blueprint;
    public turretBluePrint LucherTurretLV2Blueprint;
    public turretBluePrint LucherTurretLV3Blueprint;
    public turretBluePrint LazerTurretLV1Blueprint;
    public turretBluePrint LazerTurretLV2Blueprint;
    public turretBluePrint LazerTurretLV3Blueprint;

    private turretBluePrint turretToBuild;

    public turretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void ClearTurretToBuild()
    {
        turretToBuild = null;
    }

    public void OnBasicTurretBtnClick(int level)
    {
        if(level == 1)
        {
            turretToBuild = basicTurretLV1Blueprint;
        }
        else if(level == 2)
        {
            turretToBuild = basicTurretLV2Blueprint;
        }
        else if(level == 3)
        {
            turretToBuild = basicTurretLV3Blueprint;
        }
    }

    public void OnLuncherTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = LucherTurretLV1Blueprint;
        }
        else if (level == 2)
        {
            turretToBuild = LucherTurretLV2Blueprint;
        }
        else if (level == 3)
        {
            turretToBuild = LucherTurretLV3Blueprint;
        }
    }

    public void OnLazerTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = LazerTurretLV1Blueprint;
        }
        else if (level == 2)
        {
            turretToBuild = LazerTurretLV2Blueprint;
        }
        else if (level == 3)
        {
            turretToBuild = LazerTurretLV3Blueprint;
        }
    }

}

[System.Serializable] 
public class turretBluePrint
{
    public GameObject pref;
    public int price;
}

