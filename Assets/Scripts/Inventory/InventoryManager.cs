using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : Singleton<InventoryManager>
{
    public GameObject paint;
    public GameObject parachute;
    public GameObject paintStore;
    public GameObject parachuteStore;

    [SerializeField]
    private PlayerMovement playerScript;

    public Scene activeScene;

    private ScoreTracker score;

    private bool sceneChanged;
    
    private GameObject firstInventorySlot;
    private GameObject secondInventorySlot;
    private GameObject thirdInventorySlot;
    public Vector2 firstSlotPosition;
    public Vector2 secondSlotPosition;
    public Vector2 thirdSlotPosition;

    static List<bool> inventoryItems;

    private bool listInstantiated;
    private bool inventoryFull = false;
    private bool checkScene;

    private int highScore;
    private bool paintStored;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start()
    {
        inventoryItems = new List<bool>();

        firstInventorySlot = GameObject.FindGameObjectWithTag("Slot1");
        secondInventorySlot = GameObject.FindGameObjectWithTag("Slot2");
        thirdInventorySlot = GameObject.FindGameObjectWithTag("Slot3");

        firstSlotPosition = firstInventorySlot.transform.position;
        secondSlotPosition = secondInventorySlot.transform.position;
        thirdSlotPosition = thirdInventorySlot.transform.position;

        score = GetComponent<ScoreTracker>();

        activeScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        
        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }
        

        if (activeScene.name == "Scene1")
        {
            if (inventoryItems.Count != 0)
            {
                if (!listInstantiated)
                {
                    InstantiateGameList();
                    Debug.Log("We're in Game mode now and instantiated");
                }
            }
        }

        if (activeScene.name == "Scene3")
        {
            if (inventoryItems.Count != 0)
            {
                if (!listInstantiated)
                {
                    InstantiateStoreList();
                    Debug.Log("We're in Store Mode now");
                }  
            }
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
                    inventoryItems.Add(!paintStored);
                    listInstantiated = false;
                }
            }
        }
        else if (inventoryFull)
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
                    inventoryItems.Add(paintStored);
                    listInstantiated = false;
                }
            }
        }
        else if (inventoryFull)
            return;
    }

    //Instantiates the list for Scene1
    private void InstantiateGameList()
    {
        //Instantiate first item added, if nothing do nothing. 
        if (inventoryItems[0] != paintStored && inventoryItems[0] != !paintStored)
        {
            return;
        }
        if (inventoryItems[0] == paintStored)
        {
            Instantiate(paint, firstSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[0] == !paintStored)
        {
            Instantiate(parachute, firstSlotPosition, transform.rotation);
            Debug.Log("this should work");
            listInstantiated = true;
        }

        //Instantiate second item added, if nothing do nothing. 
        if (inventoryItems[1] != paintStored && inventoryItems[1] != !paintStored)
        {
            return;
        }
        if (inventoryItems[1] == paintStored)
        {
            Instantiate(paint, secondSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[1] == !paintStored)
        {
            Instantiate(parachute, secondSlotPosition, transform.rotation);
            listInstantiated = true;
        }

        //Instantiate third item added, if nothing do nothing. 
        if (inventoryItems[2] != paintStored && inventoryItems[2] != !paintStored)
        {
            return;
        }
        if (inventoryItems[2] == paintStored)
        {
            Instantiate(paint, thirdSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[2] == !paintStored)
        {
            Instantiate(parachute, thirdSlotPosition, transform.rotation);
            listInstantiated = true;
        }

        listInstantiated = false;
    }

    //Instantiates the list for Scene3 (Store)
    private void InstantiateStoreList()
    {
        //first inventory Item. Instantiate if not null
        if (inventoryItems[0] != paintStored && inventoryItems[0] != !paintStored)
        {
            return;
        }
        if (inventoryItems[0] == paintStored)
        {
            Instantiate(paintStore, firstSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[0] == !paintStored)
        {
            Instantiate(parachuteStore, firstSlotPosition, transform.rotation);
            Debug.Log("stored parachute");
            listInstantiated = true;
        }

        //Second inventory Item. Instantiate if not null
        if (inventoryItems[1] != paintStored && inventoryItems[1] != !paintStored)
        {
            return;
        }
        if (inventoryItems[1] == paintStored)
        {
            Instantiate(paintStore, secondSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[1] == !paintStored)
        {
            Instantiate(parachuteStore, secondSlotPosition, transform.rotation);
            listInstantiated = true;
        }

        //Third inventory Item. Instantiate if not null
        if (inventoryItems[2] != paintStored && inventoryItems[2] != !paintStored)
        {
            return;
        }
        if (inventoryItems[2] == paintStored)
        {
            Instantiate(paintStore, thirdSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[2] == !paintStored)
        {
            Instantiate(parachuteStore, thirdSlotPosition, transform.rotation);
            listInstantiated = true;
        }

        listInstantiated = false;
    }
}
