using UnityEngine;
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

	void Start ()
    {
        animator = transform.GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("No animator, dude!");
        }
	
	}

    void FixedUpdate ()
    {
        //Moves Player as he gets hit/dies
        if (dead)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            transform.Translate (windSpeed * Time.deltaTime, 0f, 0f);
            return;
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
        if (col.gameObject.tag == "Enemy")
        {
            UnityEngine.UI.Text txt = GameObject.Find("You died").GetComponent<UnityEngine.UI.Text>();
            txt.enabled = true;
            dead = true;
            animator.SetTrigger("Death");
        }
    }

    //the following below creates a coroutine that makes him invincible for x amount of time
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
    void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			points = points + 1;
		}
	}
}
