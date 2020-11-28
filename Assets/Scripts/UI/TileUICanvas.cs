using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TileUICanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI DeathText = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnEnable()
    {
        TileBehaviour.death += TextOnDeath;    
    }

    private void OnDisable()
    {
        TileBehaviour.death -= TextOnDeath;
    }

    private void TextOnDeath()
    {
        DeathText.text = "UNIT DIED!";
    }
}
