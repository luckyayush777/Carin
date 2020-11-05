using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpriteBehaviour : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0.0f , 0.0f, 5.0f));
        transform.position = new Vector3(mousePos.x, mousePos.y , mousePos.z);
    }
}
