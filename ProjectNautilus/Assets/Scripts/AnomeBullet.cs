using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnomeBullet : MonoBehaviour
{
    float shotDuration = 3f;
    PlayerController Player;
    public float damage;

    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve").GetComponent<PlayerController>();

    }

    void Update()
    {
        shotDuration -= Time.deltaTime;
        if (shotDuration <= 0)
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
     
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.health -= damage;
        }
    }

}

