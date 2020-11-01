using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { 
    MELEE = 0,
    RANGED = 1
}


public class UnitSelector : MonoBehaviour
{
    public Unit MeleeUnit;
    public GameObject MeleeUnitSpriteMini;
    public Unit RangedUnit;
    public GameObject RangedUnitSpriteMini;

    Vector3 mousePosition = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        MeleeUnitSpriteMini.transform.position = Input.mousePosition;
    }

    public void InitialiseMiniSprite(Unit unitType)
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        
        switch (unitType.m_UnitID)
        {
            case 0:
                Instantiate(MeleeUnitSpriteMini, mousePosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(RangedUnitSpriteMini, mousePosition, Quaternion.identity);
                break;
        }
    }


}
