using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHealth : MonoBehaviour
{
    // Start is called before the first frame update
    Image borderFillImage = null;
   
    void Start()
    {
        borderFillImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ReduceHealth(float damageAmount)
    {
        borderFillImage.fillAmount += damageAmount;
    }
}
