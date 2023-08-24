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
            TorpedoRef.GetComponent<Rigidbody>().AddForce(-transform.right * TorpedoSpeed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.GetComponent<CapsuleCollider>().enabled = false;
            Player.GetComponent<BoxCollider>().enabled = true;


            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.SetParent(Player.transform, false);
            transform.Translate(0, 1.2f, 0);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
