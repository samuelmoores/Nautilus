using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    GameObject Player;
    public GameObject Torpedo;
    GameObject TorpedoRef;
    public float TorpedoSpeed;
    public Transform TorpedoLoc;
    bool canIntereact;
  
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve");
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            TorpedoRef = Instantiate(Torpedo, TorpedoLoc.position, TorpedoLoc.rotation);
            TorpedoRef.GetComponent<Rigidbody>().AddForce(transform.forward * TorpedoSpeed, ForceMode.Impulse);
        }

        if(canIntereact && Player.GetComponent<PlayerController>().isInteracting)
        {
            Player.GetComponent<CapsuleCollider>().enabled = false;
            Player.GetComponent<PlayerController>().isDrivingSubmarine = true;

            transform.position = Player.transform.position;
            transform.rotation = Quaternion.Euler(0, Player.transform.eulerAngles.y, 0);
            transform.SetParent(Player.transform, false);
            transform.Translate(0, 1.2f, 0);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canIntereact = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canIntereact = false;
        }
    }

}
