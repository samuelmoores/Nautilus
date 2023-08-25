using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointRespawn : MonoBehaviour
{
    public GameObject Checkpoint;
    //Transform respawnPos;
    
    
    //private Vector3 = Transform.position;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
            Checkpoint = collision.GetComponent<GameObject>();
        }
        // TODO: When player dies, restart scene and move player to checkpoint.
    }
    

}
