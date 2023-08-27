using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    GameManager gameManager;
    Vector2 movement;
    Vector3 rotation;
    public float swimSpeed;
    public float rotateSpeed;
    [HideInInspector] public float health;
    [HideInInspector] public bool isInteracting;
    [HideInInspector] public bool takingDamage = false;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isDrivingSubmarine = false;
    float respawnTimer = 5f;
    float currentRespawnTimer;
    Transform CurrentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<CapsuleCollider>().enabled = true;
        health = 1.0f;
        Physics.gravity = new Vector3(0, -2, 0);
        currentRespawnTimer = respawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x = Input.GetAxis("Horizontal");
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement.Normalize();

        if(takingDamage)
        {
            animator.SetBool("takingDamage", true);
            health -= Time.deltaTime / 3f;

            if (health < 0.01)
            {
                Death();
            }

        }else
        {
            animator.SetBool("takingDamage", false);

        }

        if (!isDead)
            Move();
        else
        {
            if (currentRespawnTimer > 0.01f)
            {
                currentRespawnTimer -= Time.deltaTime;
            }
            else
            {
                Respawn();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            isInteracting = false;
        }

        if (health < 0.01)
        {
            animator.SetBool("takingDamage", true);
            Death();

        }

    }

    private void Move()
    {
        rb.AddForce(movement * swimSpeed, ForceMode.Impulse);

        if (movement != Vector2.zero)
        {
            animator.SetBool("isSwimming", true);
        }
        else
        {
            animator.SetBool("isSwimming", false);
        }

        if (rotation != Vector3.zero)
        {
                Quaternion toRotation = Quaternion.LookRotation(-rotation, Vector3.up) * Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }

    void Death()
    {
        isDead = true;
        health = 0;
        animator.SetBool("isDead", true);
        rb.freezeRotation = false;

    }

    void Respawn()
    {
        takingDamage = false;
        isDead = false;
        animator.SetBool("isDead", false);
        health = 1.0f;
        currentRespawnTimer = respawnTimer;
        transform.position = CurrentCheckpoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            CurrentCheckpoint = other.transform;
        }

        if(other.CompareTag("Enemy"))
        {
            takingDamage = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            takingDamage = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDrivingSubmarine)
        {
            takingDamage = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            takingDamage = false;
        }
    }

}
