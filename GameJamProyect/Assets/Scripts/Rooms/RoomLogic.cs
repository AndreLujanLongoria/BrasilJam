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
        int dialogue = (int)currentFase;
        switch (nextRoom)
        {
            case Room.HOSPITAL:
                kinderFase.EndFase();
                hospitalFase.StartFase(currentFase);

                break;
            case Room.KINDER:
                hospitalFase.EndFase();
                kinderFase.StartFase(currentFase);

                break;
            default:
                break;
        }
        dialogue = dialogue >= 4 ? 3 : dialogue;
        if (dialogue < 3&& narrative != null)
            narrative.ShowText(dialogue, NarrativeEvent.ROOM);
    }

}

public enum Room { HOSPITAL, KINDER };