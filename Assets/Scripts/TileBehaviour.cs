using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    Color defaultColor = new Color();
    public Color onHoveringColor = new Color();
    public static bool cursorEmpty = false;
    void Start()
    {
        defaultColor = this.GetComponent<SpriteRenderer>().color;
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
