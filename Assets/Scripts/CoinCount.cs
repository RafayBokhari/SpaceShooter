using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Coin;
    [SerializeField] Text coinText;
    private int Count = 0;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coin.text = Count.ToString();
        coinText.text = "Coins : " + Count.ToString();
    }

    public void AddCount()
    {
        Count++;
    }
}
