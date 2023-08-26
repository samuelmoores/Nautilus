using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    public int numOfCoins;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + numOfCoins.ToString();
    }
}
