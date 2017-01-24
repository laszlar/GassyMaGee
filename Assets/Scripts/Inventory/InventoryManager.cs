using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : Singleton<InventoryManager>
{
    private bool inventoryFull;

    public GameObject paint;
    public GameObject parachute;
    public GameObject paintStore;
    public GameObject parachuteStore;

    [SerializeField]
    private PlayerMovement playerScript;
    public Scene activeScene;

    private ScoreTracker score;

    private GameObject firstInventorySlot;
    private GameObject secondInventorySlot;
    private GameObject thirdInventorySlot;
    public Vector2 firstSlotPosition;
    public Vector2 secondSlotPosition;
    public Vector2 thirdSlotPosition;

    //List <GameObject> inventoryItems = new List<GameObject>();
    List<bool> inventoryItems = new List<bool>();

    private int highScore;
    private bool listInstantiated;
    private bool paintStored;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Use this for initialization
    void Start ()
    {
        score = GetComponent<ScoreTracker>();

        firstInventorySlot = GameObject.FindGameObjectWithTag("Slot1");
        secondInventorySlot = GameObject.FindGameObjectWithTag("Slot2");
        thirdInventorySlot = GameObject.FindGameObjectWithTag("Slot3");

        firstSlotPosition = firstInventorySlot.transform.position;
        secondSlotPosition = secondInventorySlot.transform.position;
        thirdSlotPosition = thirdInventorySlot.transform.position;

        listInstantiated = false;

        activeScene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }

        if (inventoryItems[0] != null || inventoryItems[1] != null || inventoryItems[2] != null)
        {
            if (!listInstantiated)
                InstantiateList();
        }
	}

    public void ParachuteButton()
    {
        if (!inventoryFull)
        {
            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetInt("High Score");

                if (highScore >= 5)
                {
                    highScore -= 5;
                    PlayerPrefs.SetInt("High Score", highScore);
                    PlayerPrefs.Save();
                    //inventoryItems.Add(parachute);
                    inventoryItems.Add(!paintStored);
                    listInstantiated = false;
                }
            }
        }
        else
            return;
    }

    public void PaintButton()
    {
        if (!inventoryFull)
        {
            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetInt("High Score");

                if (highScore >= 10)
                {
                    highScore -= 10;
                    PlayerPrefs.SetInt("High Score", highScore);
                    PlayerPrefs.Save();
                    //inventoryItems.Add(paint);
                    inventoryItems.Add(paintStored);
                    listInstantiated = false;
                }
            }  
        }
        else
            return;
    }

    private void InstantiateList()
    {
        /*Instantiate(inventoryItems[0], firstSlotPosition, transform.rotation);
        listInstantiated = true;
        Instantiate(inventoryItems[1], secondSlotPosition, transform.rotation);
        listInstantiated = true;
        Instantiate(inventoryItems[2], thirdSlotPosition, transform.rotation);
        listInstantiated = true;
        */
        
        if (activeScene.name == "Scene1")
        {
            if (inventoryItems[0] == paintStored)
            {

            }
        }    
    }
}
