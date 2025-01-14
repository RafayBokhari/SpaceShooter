using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Image Bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetAmount(float amount)
    {
        Bar.fillAmount = amount;
    }
   
}
