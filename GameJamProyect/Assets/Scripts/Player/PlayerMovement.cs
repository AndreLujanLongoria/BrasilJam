using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    Vector3 movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        GetMovement();
        Move();
       
    }
    void GetMovement()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        Vector3 newVelocity = movement * speed * Time.deltaTime;

        rb.velocity = newVelocity;
    }
}
