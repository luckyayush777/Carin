using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    public int m_unitID;
    public string m_unitName;
    public int health = 40;
    public int attackDamage = 10;

    public void ResetAttributes()
    {
        m_unitID = 0;
        m_unitName = "";
        health = 0;
        attackDamage = 0;
    }
}
