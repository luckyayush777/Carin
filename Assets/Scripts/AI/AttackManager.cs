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
    public static bool unitDied = false;
    [SerializeField]
    private Sprite PlayerTilePrimitive = null;


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
            if (m_attackedTileInstance.health == 0)
                SetAttributesCapturedTiles(m_attackedTileInstance);
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
                if (m_attackedTileInstance.m_unitName == "Ranged") 
                {
                    m_attackedTileInstance.health -= m_attackerTileInstance.attackDamage * 2;
                }
                else if (m_attackedTileInstance.m_unitName == "Melee")
                {
                    m_attackedTileInstance.health -= m_attackerTileInstance.attackDamage;
                }
            }
        }
        if (m_attackerTileInstance.m_unitName == "Ranged")
        {
            if (m_attackedTileInstance.m_unitName == "Ranged")
            {
                m_attackedTileInstance.health -= m_attackerTileInstance.attackDamage;
            }
            else if (m_attackedTileInstance.m_unitName == "Melee")
            {
                m_attackedTileInstance.health -= m_attackerTileInstance.attackDamage * 2;
            }
        }
        if(m_attackedTileInstance.health == 0)
        {
            unitDied = true;
            m_attackedTileInstance.GetComponent<SpriteRenderer>().sprite = PlayerTilePrimitive;
            m_attackedTileInstance.ResetAttributes();
            m_attackedTileInstance.GetComponent<Tile>().allocatedToEnemy = false;
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
        return true;
    }

    private void SetAttributesCapturedTiles(UnitBehaviour unitBehaviour)
    {
        switch (unitBehaviour.m_unitID)
        {
            case 0: unitBehaviour.health = 40;
                unitBehaviour.attackDamage = 10;
                break;
            case 1: unitBehaviour.health = 40;
                unitBehaviour.attackDamage = 10;
                break;
        }
    }


}
