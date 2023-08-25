using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerController Player;
    Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve").GetComponent<PlayerController>();
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = Player.health;
    }
}
