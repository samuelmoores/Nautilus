using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position = Vector3.zero; 
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.SetParent(Player.transform, false);
            transform.Translate(0, 1.2f, 0);

        }
    }
}
