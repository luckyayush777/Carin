using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState
{
    EMPTY_TILE,
    COVERED_TILE

}

public class TileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public TileState tileState = TileState.EMPTY_TILE;
    Color defaultColor = new Color();
    public Color onHoveringColor = new Color();
    private UnitSelector unitSelector;
    public static bool clickedTile = false;
    private Tile tileInfo;
    private UnitBehaviour unitBehaviour;
    private AttackManager attackManager;
    private void Awake()
    {
        attackManager = FindObjectOfType<AttackManager>();
        unitSelector = FindObjectOfType<UnitSelector>();
        if (unitSelector == null)
        {
            Debug.Log("could not find unit selector script");
        }
        tileInfo = GetComponent<Tile>();
        unitBehaviour = GetComponent<UnitBehaviour>();
        if (unitBehaviour == null)
        {
            Debug.Log("could not find unit behaviour script");
        }
    }
    void Start()
    {
        defaultColor = GetComponent<SpriteRenderer>().color;
        
    }

    // Update is called once per frame
    void Update()
    {
        clickedTile = false;
        Die();
    }
    

    private void OnClickEmptyTileBehaviour()
    {
        if (!tileInfo.allocatedToEnemy)
        {
            clickedTile = true;
            Sprite spriteToUse = unitSelector.getTypeOfSprite();
            if (spriteToUse != null)
            {
                GetComponent<SpriteRenderer>().sprite = spriteToUse;
                tileState = TileState.COVERED_TILE;
            }
            if (unitSelector.getUnitType() == UnitType.MELEE)
            {
                unitBehaviour.m_unitID = 0;
                unitBehaviour.m_unitName = "Melee";
            }
            else if (unitSelector.getUnitType() == UnitType.RANGED)
            {
                unitBehaviour.m_unitID = 1;
                unitBehaviour.m_unitName = "Ranged";
            }
        }
    }
 
    private void OnMouseUp()
    {
        
    }

    private void OnMouseDown()
    {
        if(tileState == TileState.EMPTY_TILE)
        OnClickEmptyTileBehaviour();
        else if(tileState == TileState.COVERED_TILE)
        {
            if (!tileInfo.allocatedToEnemy)
            {
                SetAttributesOfTileAttacker();
               
            }
        }
        if (tileInfo.allocatedToEnemy)
        {
            SetAttributesOfTileAttacked();
            
        }
    }

    private void OnMouseOver()
    {
        if (!tileInfo.allocatedToEnemy)
        GetComponent<SpriteRenderer>().color = onHoveringColor;
    }

    private void OnMouseExit()
    {
        if(!tileInfo.allocatedToEnemy)
        GetComponent<SpriteRenderer>().color = defaultColor;
    }

    private void SetAttributesOfTileAttacker()
    {
        attackManager.SetAttackerTileInstance(unitBehaviour);
        attackManager.SetAttackerTileInfo(tileInfo);
    }

    private void SetAttributesOfTileAttacked()
    {
        attackManager.SetAttackedTileInfo(tileInfo);
        attackManager.SetAttackedTileInstance(unitBehaviour);
    }

    private void Die()
    {
        if(unitBehaviour.health == 0)
        {
            Debug.Log("DIED!");
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }

}
