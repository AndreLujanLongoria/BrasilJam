using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrayonInteraction : InteractableObject
{
    bool isPicked;
    float yPosition;
    private void Start()
    {
        yPosition = transform.position.y;
    }
    public override void DoInteraction(GameObject player = null)
    {
        PlayerInteraction pInteraction = player.GetComponent<PlayerInteraction>();
        if (!isPicked && !pInteraction.pickedObject)
        {
            transform.SetParent(pInteraction.pickPosition.transform);
            transform.localPosition = new Vector3(0, 0, 0);
            isPicked = true;
            pInteraction.pickedObject = true;
        }
    }

    public void Draw()
    {
        gameObject.SetActive(false);
    }
}
