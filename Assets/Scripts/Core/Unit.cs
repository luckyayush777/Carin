using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public string m_UnitName;
    public int m_UnitID;

    public Unit(string name = "" , int UnitID = 0)
    {
        m_UnitName = name;
        m_UnitID = UnitID;
    }
}
