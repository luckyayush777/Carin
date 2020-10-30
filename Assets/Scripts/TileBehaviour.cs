using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    Color defaultColor = new Color();
    public Color onHoveringColor = new Color();
    [SerializeField]
    private Sprite unitSprite = null;
    [SerializeField]
    private Sprite archerSprite = null;
    public static bool cursorEmpty = false;
    void Start()
    {
        defaultColor = this.GetComponent<SpriteRenderer>().color;
        //onHoveringColor = new Color(1.0f , 0.0f , 0.0f , 1.0f);
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
        //Debug.Log("CLICKED TILE!");
        ChangeSprite(unitSprite);
        Vector3 lTemp = transform.localScale;

        // TO DO : remove hard coded scaling values/ get a better solution
        lTemp.x *= 0.16f;
        lTemp.y *= 0.07f;
        transform.localScale = lTemp;
        cursorEmpty = true;
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = onHoveringColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = defaultColor;
    }

    private void ChangeSprite(Sprite spriteType) => GetComponent<SpriteRenderer>().sprite = spriteType;

}
