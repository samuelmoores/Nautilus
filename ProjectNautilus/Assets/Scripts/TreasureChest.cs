using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    Animator animator;
    public GameObject Coin;
    List<GameObject> CoinInstances;
    GameObject CoinInstance;
    bool opened = false;
    float collectionTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        CoinInstances = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(opened)
        {
            collectionTimer -= Time.deltaTime;

            for(int i = 0; i < CoinInstances.Count; i++)
            {
                if (CoinInstances[i] != null)
                {
                    
                     CoinInstances[i].transform.position = new Vector3(CoinInstances[i].transform.position.x, CoinInstances[i].transform.position.y, 0); 
                    
                }
            }
            
            if(collectionTimer <= 0 )
            {
                for(int i = 0; i < CoinInstances.Count; i++)
                {
                    if(CoinInstances[i] != null)
                    {
                        CoinInstances[i].GetComponent<Collectible>().canCollect = true;

                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player") && !opened)
        {
            animator.SetBool("Open", true);

            for(int i = -15; i < 15; i += 5)
            {
                CoinInstance = Instantiate(Coin, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);

                CoinInstances.Add(CoinInstance);

                CoinInstance.GetComponent<Rigidbody>().AddForce(new Vector3(i, 15, 0), ForceMode.Impulse);

            }

            opened = true;

        }
    }
}
