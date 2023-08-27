using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    GameManager gameManager;
    GameObject coinsUI;

     public bool canCollect = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        coinsUI = GameObject.Find("CoinsHUD");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && canCollect)
        {
            Destroy(gameObject);
            coinsUI.GetComponent<CoinsUI>().numOfCoins++;
        }
    }

}
