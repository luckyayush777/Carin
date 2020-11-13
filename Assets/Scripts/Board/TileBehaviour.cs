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
    void Start()
    {
        defaultColor = this.GetComponent<SpriteRenderer>().color;
        unitSelector = FindObjectOfType<UnitSelector>();
        if (unitSelector == null)
        {
            Debug.Log("could not find unit selector script");
        }
        tileInfo = GetComponent<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        clickedTile = false;
    }
    

    private void OnClickEmptyTileBehaviour()
    {
        clickedTile = true;
        Sprite spriteToUse = unitSelector.getTypeOfSprite();
        if (spriteToUse != null)
        {
            //GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<SpriteRenderer>().sprite = spriteToUse;
            Vector2 scale = transform.localScale;
            scale.x = 1;
            scale.y = 1;
            transform.localScale = scale;
            tileState = TileState.COVERED_TILE;
        }
    }
    private void OnClickCoveredTileBehaviour()
    {
        if(unitSelector.getUnitType() == UnitType.MELEE)
        {
            Debug.Log(unitSelector.getUnitType());
        }else if(unitSelector.getUnitType() == UnitType.RANGED)
        {
            Debug.Log(unitSelector.getUnitType());
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
