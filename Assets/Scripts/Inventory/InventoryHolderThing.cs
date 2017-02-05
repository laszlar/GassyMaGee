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

    private GameObject firstInventorySlot;
    private GameObject secondInventorySlot;
    private GameObject thirdInventorySlot;
    public Vector2 firstSlotPosition;
    public Vector2 secondSlotPosition;
    public Vector2 thirdSlotPosition;

    public bool listInstantiated;
    public bool inventoryFull;
    private bool paintStored;
    #endregion

    #region Methods
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        listInstantiated = false;
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
    }

    public void InstantiateStoreList()
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
    }
    #endregion
}