using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnomeBullet : MonoBehaviour
{
    float shotDuration = 3f;

    void Update()
    {
        shotDuration -= Time.deltaTime;
        if (shotDuration <= 0)
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
     
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            PlayerController controller = GetComponent<PlayerController>();
            
            Destroy(this.gameObject);    
        }
    }

}

