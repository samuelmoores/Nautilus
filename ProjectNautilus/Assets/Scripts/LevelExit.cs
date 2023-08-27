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

    private void OnGUI()
    {
        if (beginTimer)
        {
            GUI.skin.box.fontSize = 20;
            GUI.Box(new Rect(300, 200, 500, 50), "You collected " + coinsUI.GetComponent<CoinsUI>().numOfCoins + " coins out of a possible total of " + totalCoins + "!");
            GUI.Box(new Rect(300, 300, 500, 50), "Going to the next level in " + $"{timer:0.00}" + " seconds...");
        }
    }
    void Update()
    {
        if (beginTimer)
        {
            timer -= Time.deltaTime;

        }

        if (timer < 0f)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                Debug.Log("load 1");
                SceneManager.LoadScene(1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(0);
                Debug.Log("load 0");
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
