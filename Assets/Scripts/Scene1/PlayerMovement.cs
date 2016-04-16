﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;  
    public Vector2 jumpHeight;
	public int points = 0;
    Animator anim;
    bool dead = false;
    public float windSpeed;
    public bool godMode = false;
    public float invTime = 7f;
    public int timeAfterDeath = 2;
    CameraFilterPack_TV_Old_Movie_2 camEffect;
    public int camEffectTime = 7;
    bool isGrounded = false;

	void Start ()
    {
        camEffect = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();
        camEffect.enabled = true;
        anim = transform.GetComponentInChildren<Animator>();

        if (anim == null)
        {
            Debug.LogError("No animator, dude!");
        }
	
	}

    void Update ()
    {
        //Moves Player as he gets hit/dies
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
            StartCoroutine(CamEffectOff(camEffectTime));
        }

        //makes player run
        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);

        //makes player jump
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            if(isGrounded)
            {
                //anim.SetTrigger("CompleteJump");
            }
            if(!isGrounded)
            {
                //anim.SetTrigger("MidJump");
            }
        }
        
    }

    //Kills player
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!godMode && col.gameObject.tag == "Enemy")
        { 
            dead = true;  
        }
        else if (col.gameObject.tag == "PowerUp")
        {
            SetInvincible();
        }
        else if (godMode && col.gameObject.tag == "Enemy")
        {
            Vector2 target = col.gameObject.transform.position;
            Vector2 bomb = gameObject.transform.position;
            Vector2 direction = 7f * (target - bomb);

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        }
        else if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    //the following below invokes that makes him invincible for x amount of time
    public void SetInvincible()
    {
        Debug.Log("I'm INVINCIBLE!");
        godMode = true;

        CancelInvoke("SetDamageable");
        Invoke("SetDamageable", invTime);
    }

    public void SetDamageable ()
    {
        godMode = false;
    }

    //Gives player a score
    void OnTriggerExit2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Enemy")
        {
			points = points + 1;
		}
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
        yield return new WaitForSeconds(camEffectTime);
        camEffect.enabled = true;
    }

    //Death animation
    public void DeathAnimation()
    {
        anim.SetTrigger("IsDead");
        Debug.Log("It worked?");
    }
}
