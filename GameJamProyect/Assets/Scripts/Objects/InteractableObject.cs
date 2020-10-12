using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] RoomFaseType[] hide;
    [SerializeField] string narrativeName;
    [SerializeField] NarrativeCollection narrative;
    [SerializeField] AudioSource audiosSource;
    public abstract void DoInteraction(GameObject player = null);
    public  void ActivateObject(RoomFaseType roomFase = RoomFaseType.FIRST)
    {
        if (hide == null || hide.Length == 0)
            transform.gameObject.SetActive(true);
        else if (CanActivateObject(roomFase))
            transform.gameObject.SetActive(true);
    }
    public  void DesactivateObject()
    {
        transform.gameObject.SetActive(false);
    }

    bool CanActivateObject(RoomFaseType fase)
    {
       
        for (int i = 0; i < hide.Length; i++)
        {
            if (fase == hide[i])
                return false;
        }
        return true;
    }
    protected void ShowNarrative()
    {
        narrative.ShowText(narrativeName, NarrativeEvent.OBJECT);
    }
    protected void ShowNarrative(string name)
    {
        narrative.ShowText(name, NarrativeEvent.OBJECT);
    }
    protected void PlayAudio()
    {
        audiosSource.Play();
    }
}

public enum RoomFaseType { FIRST=1, SECOND, THIRD, FOURTH, FIFTH };