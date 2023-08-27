using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public ParticleSystem _particleSystems;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, Player.transform.position));

        if(Vector3.Distance(transform.position, Player.transform.position) < 7)
        {
            _particleSystems.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
        }
    }
}
