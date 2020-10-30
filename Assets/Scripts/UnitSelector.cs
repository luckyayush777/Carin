using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSelector : EventTrigger
{ 
    private bool dragging;
    [SerializeField]
    private float snappingOffset = 1.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TileBehaviour.cursorEmpty)
        {
            dragging = false;
        }
        
        if(dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x - snappingOffset, Input.mousePosition.y - snappingOffset);
        }
    }

    public void SelectUnit()
    {
        //Debug.Log("Button Clicked");

        // unity event system
        dragging = true;
    }

    public override void OnPointerDown(PointerEventData pointerData)
    {
        //pointerData.
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //dragging = false;
    }
}
