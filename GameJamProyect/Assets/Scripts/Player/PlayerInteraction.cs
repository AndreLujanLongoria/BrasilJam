using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    InteractableObject objectToInteract;
    bool canInteract;

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            Debug.Log("Can Interact");
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectToInteract.DoInteraction(transform.gameObject);
                objectToInteract = null;
                canInteract = false;
            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        objectToInteract = other.GetComponent<InteractableObject>();
        canInteract = true;
    }
    private void OnTriggerExit(Collider other)
    {
        objectToInteract = null;
        canInteract = false;
    }
}
