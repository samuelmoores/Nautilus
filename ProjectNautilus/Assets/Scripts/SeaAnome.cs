using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaAnome : MonoBehaviour
{
    float shotTimer = 4f;
    bool shot01WasShot_lol = false;
    bool shot02WasShot_lol = false;
    bool shot03WasShot_lol = false;
    public int shotOffset;

    float shotInterval = 2.0f;
    public GameObject Bullet;
    GameObject BulletRef;

    public Transform BulletLocation1;
    public Transform BulletLocation2;
    public Transform BulletLocation3;

    private void Start()
    {
        shotTimer += shotOffset;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;

        if (shotTimer < 3 && shotTimer > 2.5f && !shot01WasShot_lol)
        {
            BulletRef = Instantiate(Bullet, BulletLocation1.position, BulletLocation1.rotation);
            BulletRef.GetComponent<Rigidbody>().AddForce(BulletLocation1.up * 15, ForceMode.Impulse);
            shot01WasShot_lol = true;
        }

        if (shotTimer < 2.49 && shotTimer > 2f && !shot02WasShot_lol)
        {
            BulletRef = Instantiate(Bullet, BulletLocation2.position, BulletLocation2.rotation);
            BulletRef.GetComponent<Rigidbody>().AddForce(BulletLocation2.up * 15, ForceMode.Impulse);
            shot02WasShot_lol = true;
        }

        if (shotTimer < 1.9 && shotTimer > 0.01f && !shot03WasShot_lol)
        {
            BulletRef = Instantiate(Bullet, BulletLocation3.position, BulletLocation3.rotation);
            BulletRef.GetComponent<Rigidbody>().AddForce(BulletLocation3.up * 15, ForceMode.Impulse);
            shot03WasShot_lol = true;
        }

        if(shotTimer < 0.01f)
        {
            shot01WasShot_lol = false;
            shot02WasShot_lol = false;
            shot03WasShot_lol = false;

            shotTimer = 4;
        }

    }
}
