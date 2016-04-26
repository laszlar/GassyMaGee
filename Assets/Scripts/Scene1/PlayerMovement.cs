using UnityEngine;
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
    public bool parachuteEnabled;
    public int parachuteTime;
    public bool duckThing;
    public bool sinkThing;
    public bool kettleThing;
    public bool scrollerThing;

	void Start ()
    {
        camEffect = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();
        camEffect.enabled = true;
        anim = transform.GetComponentInChildren<Animator>();
        parachuteEnabled = false;
        duckThing = false;
        sinkThing = false;
        kettleThing = false;
        scrollerThing = false;

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

        if (parachuteEnabled)
        {
            ParachuteMethod();
        }

        //makes player jump & play jump animation
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            anim.SetTrigger("IsGroundedJump");
        }
        
    }

    //Kills player
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
            Vector2 direction = 7f * (target - bomb);

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        }
        else if(col.gameObject.tag == "Parachute")
        {
            parachuteEnabled = true;
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

    //Gives player a score
    void OnTriggerExit2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Enemy")
        {
            if (dead)
            {
                return;
            }
            ++points;
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
    }

    //Parachute powerup
    IEnumerator ParachutePowerupEnabled (int parachuteTime)
    {
        SlowmoController();
        yield return new WaitForSeconds(parachuteTime);
        SpeedupController();
    }

    public void ParachuteMethod()
    {
        StartCoroutine(ParachutePowerupEnabled(parachuteTime));
    }

    public void SlowmoController()
    {
        duckThing = true;
        sinkThing = true;
        kettleThing = true;
        scrollerThing = true;
    }

    public void SpeedupController ()
    {
        duckThing = false;
        sinkThing = false;
        kettleThing = false;
        scrollerThing = false;
    }
}
