using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioSwitch : MonoBehaviour
{
    public AudioSource regularMusic, colorMusic, sadTrombone;
    PlayerMovement player;

    //bool
    private bool checkIfPlayed = false;

    public static MainAudioSwitch instance = null;

    private int fadeTime = 2;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        regularMusic.volume = 1.0f;
        colorMusic.volume = 0;
    }

    void Start ()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayMain(regularMusic);
        PlayColor(colorMusic);

        DecreaseThatPitchYo(regularMusic, colorMusic);

        if (player.dead && !checkIfPlayed)
        {
            regularMusic.Stop();
            colorMusic.Stop();
            sadTrombone.Play();
            checkIfPlayed = true;
        }
	}

    //if paint powerup, switch to color music.
    //the loop is supposed to decrease the volume
    //with an added fade method that starts a 
    //coroutine to wait 2 seconds per loop, but 
    //that's not working for some reason. But the
    //switch/loop does, yippee!
    private void PlayMain(AudioSource regMusic)
    {
        if (player.godMode && !player.dead)
        {
            for (int x = 0; x < 10; x++)
            {
                regMusic.volume -= 0.1f;
                Fade();
            }
        }
        else if (!player.godMode && !player.dead)
        {
            if (regMusic.volume == 0)
            {
                for (int x = 0; x < 10; x++)
                {
                    regMusic.volume += 0.1f;
                    Fade();
                }
            }
        }
    }

    private void PlayColor(AudioSource colMusic)
    {
        if (player.godMode && !player.dead)
        {
            for (int x = 0; x < 10; x++)
            {
                colMusic.volume += 0.1f;
                Fade();
            }
            
        }
        else if (!player.godMode && !player.dead)
        {
            if (colMusic.volume == 1.0f)
            {
                for (int x = 0; x < 10; x++)
                {
                    colMusic.volume -= 0.1f;
                    Fade();
                }
            }
        }
    }

    //change that funky music white boy!
    private void DecreaseThatPitchYo(AudioSource regMusic, AudioSource colMusic)
    {
        if (player.godMode)
        {
            regMusic.pitch = 1.10f;
            colMusic.pitch = 1.10f;
        }
        else if (!player.godMode)
        {
            regMusic.pitch = 1.0f;
            colMusic.pitch = 1.0f;
        }
    }

    IEnumerator GodModeEnabled(int fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
    }

    private void Fade()
    {
        StartCoroutine(GodModeEnabled(fadeTime));
    }
}
