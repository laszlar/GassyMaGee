﻿/*
The Grunt of all scripts.
-Basic player movement
-Enabling god mode.
-Coroutines for different things
!Attached to Player!
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 2f;  
    public Vector2 jumpHeight;
	public int points = 0;
    Animator anim;
    public bool dead = false;
    public float windSpeed;
    public bool godMode = false;
    public float invTime = 7f;
    public int timeAfterDeath = 2;
    CameraFilterPack_TV_Old_Movie_2 camEffect;
    public int camEffectTime = 7;
    public bool parachuteEnabled;
    int parachuteTime = 5;
    public bool duckThing;
    public bool sinkThing;
    public bool kettleThing;
    public bool scrollerThing;
    public bool punch;
    public bool isPunching;

    private bool _isEffectRunning;
    public static bool IsJumping;
    private bool _canJump;
    private float _jumpTime = 4.0f;
    private float _elapsedTime;

	void Start ()
    {
        camEffect = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();
        camEffect.enabled = true;
        anim = transform.GetComponentInChildren<Animator>();
        parachuteEnabled = false;

        if (anim == null)
        {
            Debug.LogError("No animator, dude!");
        }
	}

    void Update ()
    {
        //Moves the player
        if (!parachuteEnabled)
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);
        else
            transform.Translate((playerSpeed / 2) * Time.deltaTime, 0, 0);

        //Moves Player to the left as he gets hit/dies
        if (dead)
        {
            DeathAnimation();
            StartCoroutine(PlayerDied(timeAfterDeath));
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.Translate (windSpeed * Time.deltaTime, 0f, 0f);
            return;
        }

        if (godMode) //turn cam effect off for set amount of time in godmode
        {
            if (!_isEffectRunning)
            {
                StartCoroutine(CamEffectOff(camEffectTime));
            }
        }

        if (parachuteEnabled)
        {
            Debug.Log("you hit the parachute");
            ParachuteMethod();
        }

        //makes player jump & play jump animation
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  
        {
            if (_canJump)
            {
                GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
                anim.SetTrigger("IsGroundedJump");
                //isFarting.fart.gameObject.SetActive(true);
            }
        }

        if (transform.position.y > 0)
        {
            IsJumping = true;
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _jumpTime)
            {
                _canJump = false;

            }
        }
        else
        {
            IsJumping = false;
            _canJump = true;
            _elapsedTime = 0;
        }
        
    }

    //Kills player, 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!godMode && col.gameObject.tag == "Enemy")
        { 
            dead = true;  
        }
        else if (col.gameObject.tag == "Paint")
        {
            SetInvincible();
        }
        else if (godMode && col.gameObject.tag == "Enemy")
        {
            Vector2 target = col.gameObject.transform.position;
            Vector2 bomb = gameObject.transform.position;
            Vector2 direction = 14 * (target - bomb);

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        }
        ///////////////////////Parachute Methods///////////////////////////////////
        /*else if(col.gameObject.tag == "Parachute")
        {
            Debug.Log("you trashed that parachute");
            ParachuteMethod();
        }*/
    }

    void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Parachute")
        {
            Debug.Log("you trashed that parachute");
            ParachuteMethod();
        }
    }
    
    //the following below invokes that makes him invincible for x amount of time
    public void SetInvincible()
    {
        godMode = true;

        CancelInvoke("SetDamageable");
        Invoke("SetDamageable", invTime);
    }

    public void SetDamageable ()
    {
        godMode = false;
    }

    //Gives player a score && Resets punch upon exit
    void OnTriggerExit2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Enemy")
        {
              if (dead)
              {
                   return;
              }
            ++points;
            punch = false;
            isPunching = false;
		}
	}

    //Punch enemies upon entering collider
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (godMode && coll.gameObject.tag == "AnimTrigger")
        {
            if (!punch)
            {
                PunchAnimation();
                isPunching = true;
            }
        }
    }

    //Punch Animation
    public void PunchAnimation()
    {
        punch = true;
        isPunching = true;
        //anim.SetTrigger("IsPunch");
    }

    //Wait to change scene after death
    IEnumerator PlayerDied (int timeAfterDeath)
    {
        yield return new WaitForSeconds(timeAfterDeath);
        SceneManager.LoadScene("Scene2");
    }

    //This will turn the camera off for X amount of time
    IEnumerator CamEffectOff (int camEffectTime)
    {
        camEffect.enabled = false;
        _isEffectRunning = true;
        yield return new WaitForSeconds(camEffectTime);
        camEffect.enabled = true;
        _isEffectRunning = false;
    }

    //Death animation
    public void DeathAnimation()
    {
        anim.SetTrigger("IsDead");
    }

    //Parachute power down!!
    IEnumerator ParachutePowerupEnabled (int parachuteTime)
    {
        parachuteEnabled = true;
        yield return new WaitForSeconds(parachuteTime);
        parachuteEnabled = false;
    }

    //Parachute coroutine
    public void ParachuteMethod()
    {
        StartCoroutine(ParachutePowerupEnabled(parachuteTime));
    }

}
