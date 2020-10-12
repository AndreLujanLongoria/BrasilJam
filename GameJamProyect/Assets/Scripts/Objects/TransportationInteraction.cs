using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationInteraction : InteractableObject
{
    [SerializeField] RoomLogic roomLogic;
    [SerializeField] RoomFaseType nextFase;
    [SerializeField] Room nextRoom;
    public override void DoInteraction(GameObject player = null)
    {
        RoomLogic.currentFase = nextFase;
        roomLogic.ChangeFase(nextRoom);
    }

   
    
}
