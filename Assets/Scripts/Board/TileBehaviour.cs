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
    private UnitType unitTypeOnTile;
    void Start()
    {
        defaultColor = this.GetComponent<SpriteRenderer>().color;
        unitSelector = FindObjectOfType<UnitSelector>();
        if (unitSelector == null)
        {
            Debug.Log("could not find unit selector script");
        }
        tileInfo = GetComponent<Tile>();
        unitBehaviour = GetComponent<UnitBehaviour>();
        if(unitBehaviour == null)
        {
            Debug.Log("could not find unit behaviour script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        clickedTile = false;
    }
    

    private void OnClickEmptyTileBehaviour()
    {
        if (!tileInfo.allocatedToEnemy)
        {
            clickedTile = true;
            Sprite spriteToUse = unitSelector.getTypeOfSprite();
            if (spriteToUse != null)
            {
                //GetComponent<SpriteRenderer>().sprite = null;
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
    private void OnClickCoveredTileBehaviour()
    {
        if (!tileInfo.allocatedToEnemy)
        {
            if (unitSelector.getUnitType() == UnitType.MELEE)
            {
                Debug.Log(unitSelector.getUnitType());
            }
            else if (unitSelector.getUnitType() == UnitType.RANGED)
            {
                Debug.Log(unitSelector.getUnitType());
            }
        }
    }
    private void OnMouseUp()
    {
        //clickedTile = false;
    }

    private void OnMouseDown()
    {
        if(tileState == TileState.EMPTY_TILE)
        OnClickEmptyTileBehaviour();
        else if(tileState == TileState.COVERED_TILE)
        {
            OnClickCoveredTileBehaviour();
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

}
