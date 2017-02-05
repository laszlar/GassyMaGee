using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : Singleton<InventoryManager>
{
    //private bool inventoryFull;

    /*
    [SerializeField]
    GameObject paint;
    [SerializeField]
    GameObject parachute;
    [SerializeField]
    GameObject paintStore;
    [SerializeField]
    GameObject parachuteStore;
    */

    public GameObject playerInventory;
    public InventoryHolderThing inventory;

    [SerializeField]
    private PlayerMovement playerScript;

    public Scene activeScene;

    private ScoreTracker score;

    /*
    private GameObject firstInventorySlot;
    private GameObject secondInventorySlot;
    private GameObject thirdInventorySlot;
    public Vector2 firstSlotPosition;
    public Vector2 secondSlotPosition;
    public Vector2 thirdSlotPosition;

    static List<bool> inventoryItems = new List<bool>();

    private bool listInstantiated;
    */

    private int highScore;
    private bool paintStored;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start()
    {
        //InstantiateList();

        /*
        firstInventorySlot = GameObject.FindGameObjectWithTag("Slot1");
        secondInventorySlot = GameObject.FindGameObjectWithTag("Slot2");
        thirdInventorySlot = GameObject.FindGameObjectWithTag("Slot3");

        firstSlotPosition = firstInventorySlot.transform.position;
        secondSlotPosition = secondInventorySlot.transform.position;
        thirdSlotPosition = thirdInventorySlot.transform.position;

        listInstantiated = false;
        */
        playerInventory = GameObject.Find("PlayerInventory");
        inventory = playerInventory.GetComponent<InventoryHolderThing>();
        score = GetComponent<ScoreTracker>();

        activeScene = SceneManager.GetActiveScene();
        Debug.Log(activeScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }
        */

        if (activeScene.name == "Scene1")
        {
            if (InventoryHolderThing.inventoryItems.Count != 0)
            {
                if (!inventory.listInstantiated)
                    inventory.InstantiateGameList();
            }
        }

        if (activeScene.name == "Scene3")
        {
            if (InventoryHolderThing.inventoryItems.Count != 0)
            {
                if (!inventory.listInstantiated)
                    inventory.InstantiateStoreList();
            }
        }
    }

    public void ParachuteButton()
    {
        if (!inventory.inventoryFull)
        {
            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetInt("High Score");

                if (highScore >= 5)
                {
                    highScore -= 5;
                    PlayerPrefs.SetInt("High Score", highScore);
                    PlayerPrefs.Save();
                    InventoryHolderThing.inventoryItems.Add(!paintStored);
                    inventory.listInstantiated = false;
                }
            }
        }
        else if (inventory.inventoryFull)
            return;
    }

    public void PaintButton()
    {
        if (!inventory.inventoryFull)
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
                    InventoryHolderThing.inventoryItems.Add(paintStored);
                    inventory.listInstantiated = false;
                }
            }
        }
        else if (inventory.inventoryFull)
            return;
    }

    /*private void InstantiateList()
    {
        if (activeScene.name == "Scene1")
        {
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

            listInstantiated = true;
        }

        if (activeScene.name == "Scene3")
        {
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

            listInstantiated = true;
        }
    }
    */
}
