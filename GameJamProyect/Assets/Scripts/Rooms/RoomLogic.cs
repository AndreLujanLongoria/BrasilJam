using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLogic : MonoBehaviour
{
   [SerializeField] RoomFase hospitalFase;
   [SerializeField] RoomFase kinderFase;
   [SerializeField] NarrativeCollection narrative;

    public static RoomFaseType currentFase;
    // Start is called before the first frame update
    void Start()
    {
        currentFase = RoomFaseType.FIRST;
        hospitalFase.EndFase();
        kinderFase.EndFase();

        hospitalFase.StartFase();
        narrative.ShowText(0, NarrativeEvent.ROOM);
    }

    public void ChangeFase(Room nextRoom)
    {
        int dialogue= (int)currentFase;
        switch (nextRoom)
        {
            case Room.HOSPITAL:
                kinderFase.EndFase();
                hospitalFase.StartFase(currentFase);
                narrative.ShowText(dialogue, NarrativeEvent.ROOM);
                break;
            case Room.KINDER:
                hospitalFase.EndFase();
                kinderFase.StartFase(currentFase);
                narrative.ShowText(dialogue, NarrativeEvent.ROOM);
                break;
            default:
                break;
        }
    }

}

public enum Room { HOSPITAL,KINDER};