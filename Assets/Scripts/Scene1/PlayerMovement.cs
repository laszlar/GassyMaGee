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
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    #region Global Variables
    private float counter = 0.05f;
    private GameObject player;
    public float playerSpeed = 2f;
    public Vector2 jumpHeight;
    public int points = 0;
    private  Animator anim;
    public bool dead = false;
    public bool explDeath = false;
    public float windSpeed;
    public bool godMode = false;
    public float invTime = 7f;
    public int timeAfterDeath = 4;
    private CameraFilterPack_TV_Old_Movie_2 camEffect;
    public int camEffectTime = 7;
    public bool parachuteEnabled;
    private bool parachuteCreated;
    public GameObject parachuteAnim;
    private ParachuteFollowPlayer parachuteScript;
    public bool bananaEnabled;
    int parachuteTime = 5;
    int bananaTime = 2;
    private bool jumpedOnBouncyWoman;

    //Audio Source 
    public AudioSource parachuteSound;

    float timeCounter;

    private bool _isEffectRunning;
    public static bool IsJumping;
    private bool _canJump;
    private float _jumpTime = 1.0f;
    private float _elapsedTime;
    private float _maxJumpVelocity = 3f;

    private Rigidbody2D _rb2D;
    private RigidbodyConstraints2D rigidConstraints;
	private Transform _child;
	public static bool _isEnemy;
	private Collider2D _collider;

    //Here I will put the variables in for the touch 
    //response. Responsible for increasing Gassy's 
    //scale. 
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float deltaTouch = 0f;
    private float delta;
    private float maxSize;
    private float minSize;
    private bool beanAbility;
    //timer and bools for swiping
    public static bool swiped = false;
    public static bool swipeEnabler = true;
    public static bool startTimer = false;
    private bool swipeOnce;
    private int swipeTimeLimit = 4;
    private float swipeTimer = 0f;
    public static bool fingerMoved = false;

    private float touchCounter = 0f;
    private int troubleshootCounter = 0;
    //setting the sclae
    private static Vector3 adjustableScale;
    private float setScaleX = 1.0f;
    private float setScaleY = 1.0f;
    private float minScale = 0.40f;
    private float maxScale = 3.0f;

    //collission for enemies
    private bool jumpedOnDog;
    private bool jumpedOnCow;

    /*//audio
    public AudioSource bananaSource;
    public AudioSource parachuteSource;
    */
    #endregion

    #region MonoBehaviors

    void Start()
    {
        jumpedOnBouncyWoman = false;
        jumpedOnCow = false;
        jumpedOnDog = false;
        swipeTimer = 0f;
        swipeEnabler = true;
        camEffect = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();
        camEffect.enabled = true;
        anim = transform.GetComponentInChildren<Animator>();
        parachuteEnabled = false;
        parachuteCreated = false;

		_child = transform.Find("Player GFX");

        _rb2D = GetComponent<Rigidbody2D>();

        if (anim == null)
        {
            Debug.LogError("No animator, dude!");
        }

        player = GameObject.Find("Player");

        //for the parachute animation
        parachuteScript = GetComponent<ParachuteFollowPlayer>();

        //Scaling stuff inserted here to reset!
        //==============================//
        //Auto-enabling bean ability for now!
        beanAbility = true;
        adjustableScale = new Vector3(setScaleX, setScaleY, 1);
        transform.localScale = adjustableScale;
        //=============================//
    }

    void Update()
    {
        if (_isEnemy)
        {
            _elapsedTime -= 0.4f;
        }

        //Moves Player to the left as he gets hit/dies
        if (dead && !_isEnemy)
        {
            godMode = false;
            parachuteEnabled = false;
            bananaEnabled = false;
            DeathAnimation();
            StartCoroutine(PlayerDied(timeAfterDeath));
            _rb2D.isKinematic = true;
            _rb2D.velocity = Vector2.zero;
            return;
        }

        if (explDeath)
        {
            ExplodedDeathAnimation();
            StartCoroutine(PlayerDied(timeAfterDeath));
            _rb2D.isKinematic = true;
            _rb2D.gravityScale = 0;
            //rigidbodyconstraints... enum, doesn't really work.
            _rb2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            _rb2D.velocity = Vector2.zero;
            return;
        }

        if (godMode) //turn cam effect off for set amount of time in godmode
        {
            if (!_isEffectRunning)
            {
                StartCoroutine(CamEffectOff(camEffectTime));
            }
        }

#if UNITY_EDITOR
        //======OLD TAP LOGIC HERE=======//
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

                    //Recording Gassy's initial swipe position here...
                    startTouchPosition = Input.mousePosition;

                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            swipeOnce = true;
        }

        deltaTouch = endTouchPosition.y - startTouchPosition.y;
        delta = (endTouchPosition.y - startTouchPosition.y) / Mathf.Abs(startTouchPosition.y);
        //SwipeMethod();
        NewSwipeMethod();
        ResetSwipeTimer();
#endif

        if (!bananaEnabled)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (_canJump)
                    {
                        _rb2D.AddForce(jumpHeight, ForceMode2D.Impulse);
                        anim.SetTrigger("IsGroundedJump");
                    }
                }
            }
        }

            ///////////////////////////
            //Android Touch Controls//
            //////////////////////////

        int numbOfTouches = Input.touchCount;

        if (numbOfTouches > 0)
        {
            for (int i = 0; i < numbOfTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startTouchPosition = touch.position;
                        break;

                    case TouchPhase.Moved:
                        fingerMoved = true;
                        break;

                    case TouchPhase.Ended:
                        //check to see if player swiped with this boolean
                        if (fingerMoved)
                        {
                            _canJump = false;
                            endTouchPosition = touch.position;
                            swiped = true;

                            //calculate the change in touch positions with the swipe
                            deltaTouch = endTouchPosition.y - startTouchPosition.y;
                            delta = (endTouchPosition.y - startTouchPosition.y) / Mathf.Abs(startTouchPosition.y);

                            //execute the change in scale for Gassy 
                            NewSwipeMethod();
                            ResetSwipeTimer();

                            //reset the boolean for swiping
                            fingerMoved = false;
                        }
                        //if user didn't swipe, just jump!  
                        else if (!fingerMoved)
                        {
                            if (!bananaEnabled)
                            {
                                if (_canJump)
                                {
                                    _rb2D.AddForce(jumpHeight, ForceMode2D.Impulse);
                                    anim.SetTrigger("IsGroundedJump");
                                }
                            }
                        }
                        break;
                }
            }
        }

        //Disables player jump after set amount of time
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

        if (transform.position.y < -2)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, 0f);
            dead = true;
        }
        LimitJumpVelocity();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
           _isEnemy = true;
        }

        if (col.gameObject.tag == "Enemy" && col.gameObject.name == "HeftyWoman(Clone)" || col.gameObject.name == "HeftyWoman")
        {
            jumpedOnBouncyWoman = true;
        }

        if (col.gameObject.tag == "Enemy" && col.gameObject.name == "Dog(Clone)" || col.gameObject.name == "Dog")
        {
            jumpedOnDog = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (_isEnemy)
        {
            _isEnemy = false;
        }

        if (jumpedOnBouncyWoman)
        {
            jumpedOnBouncyWoman = false;
        }

        if (jumpedOnDog)
        {
            jumpedOnDog = false;
        }
    }

    void FixedUpdate()
    {
        if (!jumpedOnBouncyWoman && _isEnemy)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, (-_rb2D.velocity.y * 2f));
            points += 1;
        }

        if (jumpedOnBouncyWoman && _isEnemy)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, (-_rb2D.velocity.y * 4.0f));
            points += 1;
        }

        if (jumpedOnDog && _isEnemy)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, (_rb2D.velocity.y * 0.41f));
            points += 1;
        }
    }

    //Kills player 
    void OnCollisionEnter2D(Collision2D col)
    {
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
            points += 1;
        }
        else if(col.gameObject.tag == "Parachute")
        {
            ParachuteMethod();
            parachuteSound.Play();
        }
        else if (col.gameObject.tag == "Banana")
        {
            BananaMethod();
        }
        else if(godMode && col.gameObject.tag == "Bomb" || !godMode && col.gameObject.tag == "Bomb")
        {
            explDeath = true;
        }
    }

    #endregion

    #region Methods

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

    public void NewSwipeMethod()
    {
        if (!startTimer)
        {
            if (swipeEnabler)
            {
                if (swipeOnce)
                {
                    if (deltaTouch >= 10)
                    {
                        adjustableScale = transform.localScale;

                        adjustableScale.x *= (delta + 1);
                        adjustableScale.y *= (delta + 1);

                        adjustableScale = new Vector3(adjustableScale.x, adjustableScale.y, 1);

                        if (adjustableScale.x <= 3.0f || adjustableScale.y <= 3.0f)
                        {
                            transform.localScale = adjustableScale;
                            startTimer = true;
                        }
                    }
                }
            }
        }

        if (!startTimer)
        {
            if (swipeEnabler)
            {
                if (swipeOnce)
                {
                    if (deltaTouch <= 10)
                    {
                        adjustableScale = transform.localScale;

                        adjustableScale.x *= (delta + 1);
                        adjustableScale.y *= (delta + 1);

                        adjustableScale = new Vector3(adjustableScale.x, adjustableScale.y, 1);

                        if (adjustableScale.x >= 0.5f || adjustableScale.y >= 0.5f)
                        {
                            transform.localScale = adjustableScale;
                            startTimer = true;
                        }
                    }
                }
            }
        }
    }

    public void ResetSwipeTimer()
    {
        if (startTimer)
        {
            swipeTimer += Time.deltaTime;
        }

        if (swipeTimer > 0f && swipeTimer < 4.0f)
        {
            swipeEnabler = false;
        }

        if (swipeTimer >= 4.0f)
        {
            swipeOnce = false;
            swipeEnabler = true;
            swipeTimer = 0f;
            startTimer = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    #endregion
}
