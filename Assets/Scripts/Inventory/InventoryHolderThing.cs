using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolderThing : Singleton<InventoryHolderThing>
{
    #region Variables
    [SerializeField]
    GameObject paint;
    [SerializeField]
    GameObject parachute;
    [SerializeField]
    GameObject paintStore;
    [SerializeField]
    GameObject parachuteStore;

    public static List<bool> inventoryItems;

    private InventoryManager inventoryManager;

    private GameObject firstInventorySlot;
    private GameObject secondInventorySlot;
    private GameObject thirdInventorySlot;
    public Vector2 firstSlotPosition;
    public Vector2 secondSlotPosition;
    public Vector2 thirdSlotPosition;

    public static bool listInstantiated;
    public static bool inventoryFull;
    private bool paintStored;
    #endregion

    #region Methods
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();

        if (inventoryManager.activeScene.name == "Scene1")
        {
            listInstantiated = false;
        }
        
        if (inventoryManager.activeScene.name == "Scene3")
        {
            listInstantiated = false;
        }

        inventoryItems = new List<bool>();

        firstInventorySlot = GameObject.FindGameObjectWithTag("Slot1");
        secondInventorySlot = GameObject.FindGameObjectWithTag("Slot2");
        thirdInventorySlot = GameObject.FindGameObjectWithTag("Slot3");

        firstSlotPosition = firstInventorySlot.transform.position;
        secondSlotPosition = secondInventorySlot.transform.position;
        thirdSlotPosition = thirdInventorySlot.transform.position;
    }

    void Update()
    {
        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }

        Debug.Log(inventoryItems.Count);
    }

    public void InstantiateGameList()
    {
        //first inventory Item. Instantiate if not null
        if (inventoryItems[0] != paintStored && inventoryItems[0] != !paintStored)
        {
            return;
            Debug.Log("There's nothing Stored!");
        }
        if (inventoryItems[0] == paintStored)
        {
            Instantiate(paint, firstSlotPosition, transform.rotation);
            listInstantiated = true;
        }
        if (inventoryItems[0] == !paintStored)
        {
            Instantiate(parachute, firstSlotPosition, transform.rotation);
            Debug.Log("I just instantiated the parachute");
            listInstantiated = true;
        }

        //Second inventory Item. Instantiate if not null
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

        //Third inventory Item. Instantiate if not null
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
    }

    public void InstantiateStoreList()
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
    }
    #endregion
}