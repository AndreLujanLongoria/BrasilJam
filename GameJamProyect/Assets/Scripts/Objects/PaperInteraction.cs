using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteraction : InteractableObject
{
    int drawing = 0;
    [SerializeField] RoomLogic roomLogic;
    [SerializeField] RoomFaseType nextFase;
    [SerializeField] Room nextRoom;
    public override void DoInteraction(GameObject player = null)
    {
        ShowNarrative();
        PlayerInteraction pInteraction = player.GetComponent<PlayerInteraction>();
        if (pInteraction.pickedObject)
        {
            for (int i = 0; i < pInteraction.pickPosition.transform.childCount; i++)
            {
                pInteraction.pickPosition.transform.GetChild(i).GetComponent<CrayonInteraction>().Draw();
            }
          
           
           
            pInteraction.pickedObject = false;
            drawing += 1;
            if(drawing==3)
            {
                RoomLogic.currentFase = nextFase;
               
                roomLogic.ChangeFase(nextRoom);
            }
            
        }
    }
}
