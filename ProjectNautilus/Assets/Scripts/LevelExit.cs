using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public float timer = 10.0f;
    bool beginTimer = false;
    GameObject coinsUI;
    public int totalCoins;

    private void Start()
    {
        coinsUI = GameObject.Find("CoinsHUD");
        //coinsUI.GetComponent<CoinsUI>().numOfCoins;
    }

    void Update()
    {
        if (beginTimer)
        {
            timer -= Time.deltaTime;
            GUI.Box(new Rect(20, 20, 150, 25), "You collected " + coinsUI.GetComponent<CoinsUI>().numOfCoins + " coins out of a possible total of " + totalCoins + "!");
            GUI.Box(new Rect(20, 50, 150, 25), "Going to the next level in " + timer + "seconds...");
        }

        if (timer < 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            beginTimer = true;
        }
    }

}
