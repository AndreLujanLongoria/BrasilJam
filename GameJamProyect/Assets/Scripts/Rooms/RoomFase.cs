using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFase : MonoBehaviour
{
    [SerializeField] GameObject interactableObjectsHolder;
    [SerializeField] GameObject propsObjectHolder;

    InteractableObject[] objectsToInteract;
    public void Awake()
    {
        objectsToInteract = interactableObjectsHolder.GetComponentsInChildren<InteractableObject>();
    }
    public void StartFase(RoomFaseType fase=RoomFaseType.FIRST)
    {
       
       
        foreach (var item in objectsToInteract)
        {
            item.ActivateObject(fase);
        }

        for (int i = 0; i < propsObjectHolder.transform.childCount; i++)
        {
            propsObjectHolder.transform.GetChild(i).gameObject.SetActive(true);
        } 
    }

    public void EndFase()
    {
        
        foreach (var item in objectsToInteract)
        {
            item.DesactivateObject();
        }
        for (int i = 0; i < propsObjectHolder.transform.childCount; i++)
        {
            propsObjectHolder.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
