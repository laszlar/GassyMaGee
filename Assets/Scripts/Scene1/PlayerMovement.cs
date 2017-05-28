/*
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

    #region Global Variables
    private float counter = 0.05f;
    private GameObject player;
    public float playerSpeed = 2f;
    public Vector2 jumpHeight;
    public int points = 0;
    private int addPointsPerSecond = 1;
    private  Animator anim;
    public bool dead = false;
    public bool explDeath = false;
    public float windSpeed;
    public bool godMode = false;
    public float invTime = 7f;
    public int timeAfterDeath = 2;
    private CameraFilterPack_TV_Old_Movie_2 camEffect;
    public int camEffectTime = 7;
    public bool parachuteEnabled;
    private bool parachuteCreated;
    public GameObject parachuteAnim;
    private ParachuteFollowPlayer parachuteScript;
    public bool bananaEnabled;
    int parachuteTime = 5;
    int bananaTime = 2;

    private bool _isEffectRunning;
    public static bool IsJumping;
    private bool _canJump;
    private float _jumpTime = 1.0f;
    private float _elapsedTime;
    private float _maxJumpVelocity = 3f;

    private Rigidbody2D _rb2D;
    private RigidbodyConstraints2D rigidConstraints;
	private Transform _child;
	private bool _isEnemy;
	private Collider2D _collider;

    #endregion

    #region MonoBehaviors

    void Start()
    {
        camEffect = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();
        camEffect.enabled = true;
        anim = transform.GetComponentInChildren<Animator>();
        parachuteEnabled = false;
        parachuteCreated = false;

		_child = transform.FindChild("Player GFX");

        _rb2D = GetComponent<Rigidbody2D>();

        if (anim == null)
        {
            Debug.LogError("No animator, dude!");
        }

        player = GameObject.Find("Player");

        //Repeat the AddPoints function to add to score
        InvokeRepeating("AddPoints", 3, 3);

        //for the parachute animation
        parachuteScript = GetComponent<ParachuteFollowPlayer>();
    }

    void Update()
    {
        //Moves the player
        if (!parachuteEnabled && !bananaEnabled && !dead && !explDeath)
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);
        else if (parachuteEnabled && !dead && !explDeath)
            transform.Translate((playerSpeed / 2) * Time.deltaTime, 0, 0);
		else if (bananaEnabled && !dead && !explDeath)
            transform.Translate((playerSpeed * 2) * Time.deltaTime, 0, 0);

		Transform child = transform.FindChild ("Player GFX");

        //Moves Player to the left as he gets hit/dies
        if (dead)
        {
            DeathAnimation();
            StartCoroutine(PlayerDied(timeAfterDeath));
            _rb2D.isKinematic = true;
            return;
        }

        if (explDeath)
        {
            ExplodedDeathAnimation();
            StartCoroutine(PlayerDied(timeAfterDeath));
            _rb2D.isKinematic = true;
            _rb2D.gravityScale = 0;
            //rigidbodyconstraints... enum.. works! yay.
            _rb2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
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
            ParachuteMethod();
        }

        //makes player jump & play jump animation
        //Tony, all you man :)
        if (!bananaEnabled)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (_canJump)
                {
                    _rb2D.AddForce(jumpHeight, ForceMode2D.Impulse);
                    anim.SetTrigger("IsGroundedJump");
                    //isFarting.fart.gameObject.SetActive(true);
                }
            }
        }

        //Disables player jump after set amount of time
        if (transform.position.y > 0 || transform.position.y < -0.5f)
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

        if (transform.position.y < -2)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, 0f);
            dead = true;
        }
        LimitJumpVelocity();
    }

    //Adding all the raycasts here to detect if Gassy is jumping on an enemy
        void FixedUpdate()
    {
        /*//Far left raycast
        RaycastHit2D hitFL = Physics2D.Raycast(new Vector2((transform.position.x - _child.GetComponent<Renderer>().bounds.extents.x), transform.position.y -
            _child.GetComponent<Renderer>().bounds.extents.y), Vector2.down, 0.2f);

        //Halfway left raycast
        RaycastHit2D hitHL = Physics2D.Raycast(new Vector2((transform.position.x - (0.5f * _child.GetComponent<Renderer>().bounds.extents.x)), transform.position.y -
            _child.GetComponent<Renderer>().bounds.extents.y), Vector2.down, 0.2f);
            
        //Middle raycast
        RaycastHit2D hitM = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y -
                _child.GetComponent<Renderer>().bounds.extents.y), Vector2.down, 0.2f);
        
        //Halfway right raycast
        RaycastHit2D hitHR = Physics2D.Raycast(new Vector2((transform.position.x + (0.5f * _child.GetComponent<Renderer>().bounds.extents.x)), transform.position.y -
            _child.GetComponent<Renderer>().bounds.extents.y), Vector2.down, 0.2f);
            
        //Far right raycast
        RaycastHit2D hitFR = Physics2D.Raycast(new Vector2((transform.position.x + _child.GetComponent<Renderer>().bounds.extents.x), transform.position.y -
                _child.GetComponent<Renderer>().bounds.extents.y), Vector2.down, 0.2f);
        Debug.DrawRay((new Vector3(transform.position.x, transform.position.y, transform.position.z)), Vector2.down, Color.green);
       
        //Make these raycasts work.
        IsEnemy(hitFL.collider);
        IsEnemy(hitHL.collider);
        IsEnemy(hitM.collider);
        IsEnemy(hitHR.collider);
        IsEnemy(hitFR.collider);
        */
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
        {
            if (col.gameObject.tag == "Enemy")
            {
                _isEnemy = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (_isEnemy)
        {
            _isEnemy = false;
        }
    }

    //Kills player 
    void OnCollisionEnter2D(Collision2D col)
    {
		if (_isEnemy)
        {
			_rb2D.velocity = new Vector2 (_rb2D.velocity.x, (-_rb2D.velocity.y*2f));
			Destroy (_collider.gameObject);
            points += 5;
		}
        if (!godMode && !_isEnemy && col.gameObject.tag == "Enemy")
        {
            dead = true;
        }

        //enter god mode when collided with paint canister
        else if (col.gameObject.tag == "Paint")
        {
            SetInvincible();
        }

        //funny god mode, knock enemies away when collided with player in god mode
        else if (godMode && col.gameObject.tag == "Enemy")
        {
            Vector2 target = col.gameObject.transform.position;
            Vector2 bomb = gameObject.transform.position;
            Vector2 direction = 14 * (target - bomb);

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
            points += 3;
        }
        else if(col.gameObject.tag == "Parachute")
        {
            ParachuteMethod();
        }
        else if(col.gameObject.tag == "Bomb")
        {
            explDeath = true;
        }
    }

    #endregion

    #region Methods
    //add to points function correlates with InvokeRepeating in Start Method
    private void AddPoints()
    {
        points += addPointsPerSecond;
    }

    //the following below invokes that makes him invincible for x amount of time
    public void SetInvincible()
    {
        godMode = true;

        CancelInvoke("SetDamageable");
        Invoke("SetDamageable", invTime);
    }

    public void SetDamageable()
    {
        godMode = false;
    }

    //Wait to change scene after death
    IEnumerator PlayerDied(int timeAfterDeath)
    {
        yield return new WaitForSeconds(timeAfterDeath);
        SceneManager.LoadScene("Scene2");
    }

    //This will turn the camera off for X amount of time
    IEnumerator CamEffectOff(int camEffectTime)
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

    public void ExplodedDeathAnimation()
    {
        anim.SetTrigger("IsExplDead");
    }

    //Banana Power down!
    IEnumerator BananaPowerupEnabled(int bananaTime)
    {
        bananaEnabled = true;
        //There's always money in the banana stand.
        yield return new WaitForSeconds(bananaTime);
        bananaEnabled = false;
    }

    public void BananaMethod()
    {
        StartCoroutine(BananaPowerupEnabled(bananaTime));
    }

    //Parachute power up!!
    IEnumerator ParachutePowerupEnabled(int parachuteTime)
    {
        parachuteEnabled = true;
        yield return new WaitForSeconds(parachuteTime);
        parachuteEnabled = false;
        parachuteCreated = false;
    }

    //Parachute coroutine
    public void ParachuteMethod()
    {
        StartCoroutine(ParachutePowerupEnabled(parachuteTime));
        transform.position = player.transform.position;

        if (!parachuteCreated)
        {
            Instantiate(parachuteAnim, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            parachuteCreated = true;
        }
   }

    private void LimitJumpVelocity()
    {
		if (!_isEnemy)
        {
			if (_rb2D.velocity.y > _maxJumpVelocity)
            {
				_rb2D.velocity = new Vector2 (_rb2D.velocity.x, _maxJumpVelocity);
			}
			if (_rb2D.velocity.y < -_maxJumpVelocity)
            {
				_rb2D.velocity = new Vector2 (_rb2D.velocity.x, -_maxJumpVelocity);
			}
		}
    }

    public void IsEnemy(Collider2D col)
    {
        
        //if (col != null)
        //{
            if (col.gameObject.tag == "Enemy")
            {
                _isEnemy = true;
                _collider = col;
            counter = 0.05f;
            }
            if (col == null || col != null || col.gameObject.tag != "Enemy")
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                _isEnemy = false;
            }
        }
        
            //else
            //{
                //_isEnemy = false;
            //}
            //if (col != null && col.gameObject.tag != "Enemy")
        //{
            //_isEnemy = false;
       // }
        //}
    }

    #endregion

}
