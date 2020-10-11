using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    [SerializeField] AudioClip hospitalMovementAudio;
    [SerializeField] AudioClip carpetMovementAudio;
    [SerializeField] AudioClip woodMovementAudio;

    [SerializeField] AudioSource firstAudioSource;
    [SerializeField] AudioSource secondAudioSource;

    PlayerMovement playerMovement;

    bool busy;
    bool firstClip;
   

    // Start is called before the first frame update
    void Start()
    {
        SetNewMovent(FloorMaterial.HOSPITAL);
        playerMovement = GetComponent<PlayerMovement>();
        busy = false;
        firstClip = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moving)
        {
            if (!busy)
                StartCoroutine(PlayClip());
        }
    }

    IEnumerator PlayClip()
    {

        if (!firstClip)
        {
            firstAudioSource.Play();
            busy = true;
            firstClip = true;
        }
        else 
        {
            secondAudioSource.Play();
            busy = true;
            firstClip = false;
        }
        yield return new WaitForSeconds(0.35f);
        busy = false;
    }
    public void SetNewMovent(FloorMaterial floor)
    {
        switch (floor)
        {
            case FloorMaterial.WOOD:
                firstAudioSource.clip = woodMovementAudio;
                secondAudioSource.clip = woodMovementAudio;
                break;
            case FloorMaterial.CARPET:
                firstAudioSource.clip = carpetMovementAudio;
                secondAudioSource.clip = carpetMovementAudio;
                break;
            case FloorMaterial.HOSPITAL:
                firstAudioSource.clip = hospitalMovementAudio;
                secondAudioSource.clip = hospitalMovementAudio;
                break;
            default:
                break;
        }
    }
}
public enum FloorMaterial { WOOD, CARPET, HOSPITAL }
