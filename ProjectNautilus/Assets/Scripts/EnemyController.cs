using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;
    public GameObject[] patrolRoute;
    int patrolRouteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("PF_ScubaSteve").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolRoute[patrolRouteIndex].transform.position, Time.deltaTime * 5);
        
        if(Vector3.Distance(transform.position, patrolRoute[patrolRouteIndex].transform.position) < 2)
        {
            if(patrolRouteIndex == 0)
            {
                patrolRouteIndex = 1;
                transform.rotation = Quaternion.Euler(0, 90, 0);

            }
            else if(patrolRouteIndex == 1)
            {
                patrolRouteIndex = 0;
                transform.rotation = Quaternion.Euler(0, -90, 0);

            }

        }

        Debug.Log(transform.forward);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !playerController.isDead)
        {
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        }
    }
}
