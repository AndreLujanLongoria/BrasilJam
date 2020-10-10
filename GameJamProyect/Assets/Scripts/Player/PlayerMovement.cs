using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetMovement();
        if(CanMakeStep())
        {
          //  Debug.Log("Moving");
        }
    }

    void GetMovement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    bool CanMakeStep()
    {
       Debug.Log(movement.sqrMagnitude);
        if (movement.sqrMagnitude >= .01f)
        { 
            NavMeshHit hit;
            movement = movement + transform.position * Time.deltaTime * speed;
            bool isValid = NavMesh.SamplePosition(movement, out hit, .3f, NavMesh.AllAreas);
            if (isValid)
            {
                if ((transform.position - hit.position).magnitude >= 0.02f)
                {
                    transform.position = hit.position;
                    Debug.Log("Movinga");
                }
                    
            }
            return isValid;
        }
        return false;
    }
}
