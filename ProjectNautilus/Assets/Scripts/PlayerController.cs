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
    public float targetZPosition; 
    // Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        rotation.x = Input.GetAxis("Horizontal");

        rb.AddForce(movement * swimSpeed, ForceMode.Impulse);

        if(rotation != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rotation, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);

        }else
        {
            //animator.SetBool("isSwimming", false);

        }

        if (transform.position.z != targetZPosition) // Clamped because collision were altering z axis positon.
        {   // clamp if position.z is not equal to targetZ. 
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = currentPosition + new Vector3(movement.x, 0f, movement.y) * swimSpeed * Time.deltaTime;
            newPosition.z = Mathf.Clamp(newPosition.z, targetZPosition, targetZPosition);
            rb.MovePosition(newPosition);
        }
    }
}
