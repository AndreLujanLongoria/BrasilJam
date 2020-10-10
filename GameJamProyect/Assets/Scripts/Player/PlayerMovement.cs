using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AudioClip hospitalMovementAudio;
    [SerializeField] AudioClip carpetMovementAudio;
    [SerializeField] AudioClip woodMovementAudio;

    Rigidbody rb;
    AudioSource audioSource;
    Vector3 movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hospitalMovementAudio;
    }
    void FixedUpdate()
    {
        GetMovement();
        Move();

    }
    void GetMovement()
    {
        Vector2 axisValues = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log(axisValues.magnitude);
        if (axisValues.magnitude != 0&&!audioSource.isPlaying)
            audioSource.Play();
        movement = new Vector3(axisValues.x, 0, axisValues.y);



    }

    void Move()
    {
        Vector3 newVelocity = movement * speed * Time.deltaTime;

        rb.velocity = newVelocity;
    }

    public void SetNewMovent(FloorMaterial floor)
    {
        switch (floor)
        {
            case FloorMaterial.WOOD:
                audioSource.clip = woodMovementAudio;
                break;
            case FloorMaterial.CARPET:
                audioSource.clip = carpetMovementAudio;
                break;
            case FloorMaterial.HOSPITAL:
                audioSource.clip = hospitalMovementAudio;
                break;
            default:
                break;
        }
    }
}

public enum FloorMaterial { WOOD, CARPET, HOSPITAL }