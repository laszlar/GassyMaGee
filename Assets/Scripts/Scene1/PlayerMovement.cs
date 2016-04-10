using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;  
    public Vector2 jumpHeight;
	public int points = 0;
    Animator animator;
    bool dead = false;
    public float windSpeed;
    public bool godMode = false;
    public float invTime = 7f;
    public int timeAfterDeath = 2;
    public CameraFilterPack_TV_Old_Movie_2 camEffect;
    public int camEffectTime = 7;


	void Start ()
    {
        camEffect = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();
        camEffect.enabled = true;
        animator = transform.GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("No animator, dude!");
        }
	
	}

    void Update ()
    {
        //Moves Player as he gets hit/dies
        if (dead)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
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
        }
    }

    //Kills player
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!godMode && col.gameObject.tag == "Enemy")
        {
            UnityEngine.UI.Text txt = GameObject.Find("You died").GetComponent<UnityEngine.UI.Text>();
            txt.enabled = true;
            dead = true;
            animator.SetTrigger("Death");
            StartCoroutine(PlayerDied(timeAfterDeath));
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
}
