using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState
{
    EMPTY_TILE,

}

public class TileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    Color defaultColor = new Color();
    public Color onHoveringColor = new Color();
    public static bool cursorEmpty = false;
    UnitSelector unitSelector;
    void Start()
    {
        defaultColor = this.GetComponent<SpriteRenderer>().color;
        unitSelector = FindObjectOfType<UnitSelector>();
        if (unitSelector == null)
        {
            Debug.Log("could not find unit selector script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBehaviour()
    {
        
    }

    private void OnMouseDown()
    {
        Sprite spriteToUse = unitSelector.getTypeOfSprite();
        if (spriteToUse != null)
        {
            GetComponent<SpriteRenderer>().sprite = spriteToUse;
            Vector2 scale = transform.localScale;
            // TO DO : remove hard coded values or find a new solution
            scale.x *= (float)0.140453339;
            scale.y *= (float)0.140453339;
            transform.localScale = scale;
        }
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = onHoveringColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = defaultColor;
    }

}
