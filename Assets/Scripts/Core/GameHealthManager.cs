using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHealthManager : MonoBehaviour
{
    [SerializeField]
    private Image HealthBarBorderToFill = null;
    private GameHealth GameHealthScript;
    //the more the fill of this is the more damage the player has taken

    private void Start()
    {
        GameHealthScript =  HealthBarBorderToFill.GetComponent<GameHealth>();
        if(GameHealthScript == null)
        {
            Debug.Log("Could not find the game health image or the script attached");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            DealDamage(0.05f);
        }
    }

    private void DealDamage(float amount)
    {
        GameHealthScript.ReduceHealth(amount);
    }
}
