using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
	public int points = 0;
    Animator animator;
    bool dead = false;
    public float windSpeed;

	void Start () {
        animator = transform.GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("No animator, dude!");
        }
	
	}

    // Update is called once per frame
    void Update ()
    {
        if (dead)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.6f;
            transform.Translate (windSpeed * Time.deltaTime, 0f, 0f);
            return;
        }
            

        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }

	// Fixed update is called 50X a second? 
	void FixedUpdate ()
    {

    }

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
            UnityEngine.UI.Text txt = GameObject.Find("You died").GetComponent<UnityEngine.UI.Text>();
			txt.enabled = true;
            dead = true;
            animator.SetTrigger("Death");
        }
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			points = points + 1;
		}
	}
}
