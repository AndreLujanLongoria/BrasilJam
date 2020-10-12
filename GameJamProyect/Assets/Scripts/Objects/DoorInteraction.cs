using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableObject
{
    [SerializeField] GameObject firstObjectKinder;
    [SerializeField] GameObject secondObjectKinder;
    public override void DoInteraction(GameObject player = null)
    {
        //Fisrt Fase in hospital
        if (RoomFaseType.FIRST == RoomLogic.currentFase)
        {
            firstObjectKinder.SetActive(true);
        }
        //Second Fase In Hospital
        else if (RoomFaseType.THIRD == RoomLogic.currentFase)
        {
            secondObjectKinder.SetActive(true);
        }
        //Third and final fase in Hospital
        else if (RoomFaseType.FIFTH == RoomLogic.currentFase)
        {
            Debug.Log("Final");
        }
    }


}
