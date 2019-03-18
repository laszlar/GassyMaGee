using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartAudioManager : MonoBehaviour
{
    //player script
    PlayerMovement playerScript;

    //booleans
    private bool playAudio;

    //audio clips
    public AudioClip chili;
    public AudioClip duck;
    public AudioClip fullOnDirty;
    public AudioClip kindaWet;
    public AudioClip quickBoop;

    //audio sources
    private AudioSource audioChili;
    private AudioSource audioDuck;
    private AudioSource audioFullOnDirty;
    private AudioSource audioKindaWet;
    private AudioSource audioQuickBoop;

    //array
    private AudioSource[] fartList = new AudioSource[5];

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;
    }


    private void Start()
    {
        //find script
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //adding the audio clips to the audio sources
        audioChili = AddAudio(chili, false, false, 1.0f);
        audioDuck = AddAudio(duck, false, false, 1.0f);
        audioFullOnDirty = AddAudio(fullOnDirty, false, false, 1.0f);
        audioKindaWet = AddAudio(kindaWet, false, false, 1.0f);
        audioQuickBoop = AddAudio(quickBoop, false, false, 1.0f);

        //add audio sources to the array list
        fartList[0] = audioChili;
        fartList[1] = audioDuck;
        fartList[2] = audioFullOnDirty;
        fartList[3] = audioKindaWet;
        fartList[4] = audioQuickBoop;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerScript.godMode)
        {
            fartList[Random.Range(0, 4)].Play();
        }
    }
}
