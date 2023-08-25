using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;
    NavMeshAgent agent;
    public GameObject[] patrolRoute;
    int patrolRouteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = patrolRoute[patrolRouteIndex].transform.position;
        playerController = GameObject.Find("PF_ScubaSteve").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.5)
        {
            if(patrolRouteIndex == 0)
            {
                agent.destination = patrolRoute[patrolRouteIndex++].transform.position;

            }
            else if(patrolRouteIndex == 1)
            {
                agent.destination = patrolRoute[patrolRouteIndex--].transform.position;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !playerController.isDead)
        {
            agent.isStopped = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            agent.isStopped = false;
        }
    }
}
