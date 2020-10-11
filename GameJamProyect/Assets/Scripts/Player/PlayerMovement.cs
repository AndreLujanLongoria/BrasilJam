using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject characterHolder;
    [SerializeField] GameObject characterWalk;
    [SerializeField] GameObject characterIdle;
    Rigidbody rb;

    Vector3 movement;
    [HideInInspector] public bool moving;
    GameObject currentObject;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ChangeCharacter(TypeCharacter.WALK);
    }
    void FixedUpdate()
    {
        GetMovement();
        Move();

    }
    void GetMovement()
    {
        Vector2 axisValues = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       
        if (axisValues.magnitude != 0)
        {
            ChangeCharacter(TypeCharacter.WALK);
            CheckRotation(axisValues);
        }            
        else
            ChangeCharacter(TypeCharacter.IDLE);
        moving = axisValues.magnitude != 0;
        movement = new Vector3(axisValues.x, 0, axisValues.y);

    }
    void CheckRotation(Vector2 axisValue)
    {
        if (axisValue.x < 0)
            currentObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        else
            currentObject.transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    void Move()
    {
        characterHolder.transform.LookAt(Camera.main.transform);
        Vector3 newVelocity = movement * speed * Time.deltaTime;

        rb.velocity = newVelocity;
    }
    void ChangeCharacter(TypeCharacter typeCharacter)
    {
        switch (typeCharacter)
        {
            case TypeCharacter.IDLE:
                characterWalk.SetActive(false);
                characterIdle.SetActive(true);
                currentObject = characterIdle;
                break;
            case TypeCharacter.WALK:
                characterWalk.SetActive(true);
                characterIdle.SetActive(false);
                currentObject = characterWalk;
                break;
            default:
                break;
        }
    }
}
public enum TypeCharacter { IDLE, WALK };
