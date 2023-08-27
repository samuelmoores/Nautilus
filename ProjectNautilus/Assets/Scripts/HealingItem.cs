using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    PlayerController Player;

    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.health = 1.0f;
            Destroy(this.gameObject);
        }
    }

}
