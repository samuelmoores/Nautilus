using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineBullet : MonoBehaviour
{
    public float shotTimer = 4f;

    // Update is called once per frame
    void Update()
    {
        //Destroy the projectile after an amount of time, shotTimer
        shotTimer -= Time.deltaTime;
        if (shotTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    //Destroy projectile + enemy target on collision
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
