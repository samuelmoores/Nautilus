using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadReef : MonoBehaviour
{
    public GameObject BrokenReef;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Torpedo"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Instantiate(BrokenReef, new Vector3(transform.position.x, transform.position.y - 4, transform.position.z), Quaternion.identity);
        }
    }
}
