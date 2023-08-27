using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    GameObject Player;
    GameObject PlayerModel;
    PlayerController playerController;
    SkinnedMeshRenderer playerMesh;
    public GameObject Torpedo;
    GameObject TorpedoRef;
    public float TorpedoSpeed;
    public Transform TorpedoLoc;
    bool canIntereact;
    public float fireRate;
    float shotTimer;
  
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PF_ScubaSteve");
        PlayerModel = GameObject.Find("ScubaSteve");
        playerController = Player.GetComponent<PlayerController>();
        playerMesh = PlayerModel.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        shotTimer -= Time.deltaTime;

        if(Input.GetButtonDown("Fire1") && playerController.isDrivingSubmarine && shotTimer < 0)
        {
            TorpedoRef = Instantiate(Torpedo, TorpedoLoc.position, TorpedoLoc.rotation);
            TorpedoRef.GetComponent<Rigidbody>().AddForce(transform.forward * TorpedoSpeed, ForceMode.Impulse);
            shotTimer = fireRate;
        }

        if(canIntereact && Player.GetComponent<PlayerController>().isInteracting)
        {
            Player.GetComponent<CapsuleCollider>().enabled = false;
            playerController.isDrivingSubmarine = true;
            playerMesh.enabled = false;

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
