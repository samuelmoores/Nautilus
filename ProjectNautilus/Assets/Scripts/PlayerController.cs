using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    Vector2 movement;
    Vector2 rotation;
    public float swimSpeed;
    public float rotateSpeed;
    [HideInInspector] public float health;
    [HideInInspector] public bool isInteracting;
    bool takingDamage = false;
    bool isDead = false;
    [HideInInspector] public bool isDrivingSubmarine = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        GetComponent<CapsuleCollider>().enabled = true;
        health = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation.x = Input.GetAxis("Horizontal");
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement.Normalize();

        rb.AddForce(movement * swimSpeed, ForceMode.Impulse);

        if (rotation != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(-rotation, Vector3.up) * Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);

        }

        if(movement != Vector2.zero)
        {
            animator.SetBool("isSwimming", true);
        }else
        {
            animator.SetBool("isSwimming", false);
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            isInteracting = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDrivingSubmarine)
        {
            health -= 0.2f;
        }
    }

}
