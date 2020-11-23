using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackManager : MonoBehaviour
{

    public float attackDuration = 0.0f;
    private bool attackInitiatedOnce = false;
    private UnitBehaviour m_attackerTileInstance = null;
    private UnitBehaviour m_attackedTileInstance = null;
    private Tile m_attackerTileInfo = null;
    private Tile m_attackedTileInfo = null;

    public void SetAttackerTileInstance(UnitBehaviour attackerTileInstance)
    {
        if(m_attackerTileInstance == null)
        {
            m_attackerTileInstance = attackerTileInstance;
        }
        if(m_attackerTileInstance != null)
        {
            m_attackerTileInstance = null;
            m_attackerTileInstance = attackerTileInstance;
        }
    }

    public void SetAttackedTileInstance(UnitBehaviour attackedTileInstance)
    {
        if (m_attackedTileInstance == null)
        {
            m_attackedTileInstance = attackedTileInstance;
        }
        if (m_attackedTileInstance != null)
        {
            m_attackedTileInstance = null;
            m_attackedTileInstance = attackedTileInstance;
        }
    }

    public void SetAttackerTileInfo(Tile attackerTileInfo)
    {
        m_attackerTileInfo = attackerTileInfo;
    }

    public void SetAttackedTileInfo(Tile attackedTileInfo)
    {
        m_attackedTileInfo = attackedTileInfo;
    }



    private void Update()
    {
        if(m_attackerTileInstance && m_attackedTileInstance)
        {
            if(!attackInitiatedOnce)
            InitAttackSequence();
            attackInitiatedOnce = true;
            attackDuration += Time.deltaTime;
        }
        if(attackDuration >= 1.0f)
        {
            ResetAttackSequence();
            attackDuration = 0.0f;
        }
        
    }
    public void InitAttackSequence()
    {
        if(m_attackerTileInstance.m_unitName == "Melee")
        {
            if(MeleeAttackSequencePreReq())
            {
                m_attackedTileInstance.health -= m_attackerTileInstance.attackDamage;
                Debug.Log("attacked");
            }
        }
        if (m_attackerTileInstance.m_unitName == "Ranged")
        {
            if (RangedAttackSequencePreReq())
            {
                m_attackedTileInstance.health -= m_attackerTileInstance.attackDamage;
                Debug.Log("attacked");
            }
        }
    }

    public void ResetAttackSequence()
    {
        m_attackerTileInfo = null;
        m_attackedTileInfo = null;
        m_attackerTileInstance = null;
        m_attackedTileInstance = null;
        attackInitiatedOnce = false;
    }

    private bool MeleeAttackSequencePreReq()
    {
        return (m_attackedTileInfo.boardCoordinates.yCoordinate == m_attackerTileInfo.boardCoordinates.yCoordinate - 1
               && (m_attackedTileInfo.boardCoordinates.xCoordinate == m_attackerTileInfo.boardCoordinates.xCoordinate
               || m_attackedTileInfo.boardCoordinates.xCoordinate == m_attackerTileInfo.boardCoordinates.xCoordinate - 1
               || m_attackedTileInfo.boardCoordinates.xCoordinate == m_attackerTileInfo.boardCoordinates.xCoordinate + 1));
    }

    private bool RangedAttackSequencePreReq()
    {
        return (m_attackedTileInfo.boardCoordinates.yCoordinate == m_attackerTileInfo.boardCoordinates.yCoordinate - 1
            || m_attackedTileInfo.boardCoordinates.yCoordinate == m_attackerTileInfo.boardCoordinates.yCoordinate - 2);
    }


}
