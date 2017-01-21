using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    private bool inventoryFull;

    [SerializeField]
    private GameObject paint;
    [SerializeField]
    private GameObject parachute;
    [SerializeField]
    private PlayerMovement playerScript;
    [SerializeField]

    private ScoreTracker score;

    private GameObject firstInventorySlot;
    private GameObject secondInventorySlot;
    private GameObject thirdInventorySlot;
    public Vector2 firstSlotPosition;
    public Vector2 secondSlotPosition;
    public Vector2 thirdSlotPosition;

    List <GameObject> inventoryItems = new List<GameObject>();

    private int highScore;
    private bool listInstantiated;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Use this for initialization
    void Start ()
    {
        score = GetComponent<ScoreTracker>();
        paint = GameObject.Find("PaintStoreImg");
        parachute = GameObject.Find("ParachuteStoreImg");

        firstInventorySlot = GameObject.FindGameObjectWithTag("Slot1");
        secondInventorySlot = GameObject.FindGameObjectWithTag("Slot2");
        thirdInventorySlot = GameObject.FindGameObjectWithTag("Slot3");

        firstSlotPosition = firstInventorySlot.transform.position;
        secondSlotPosition = secondInventorySlot.transform.position;
        thirdSlotPosition = thirdInventorySlot.transform.position;

        listInstantiated = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }

        if (!listInstantiated)
            InstantiateList();
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
                    inventoryItems.Add(parachute);
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
                    inventoryItems.Add(paint);
                    listInstantiated = false;
                }
            }  
        }
        else
            return;
    }

    private void InstantiateList()
    {
        Instantiate(inventoryItems[0], firstSlotPosition, transform.rotation);
        Instantiate(inventoryItems[1], secondSlotPosition, transform.rotation);
        Instantiate(inventoryItems[2], thirdSlotPosition, transform.rotation);

        listInstantiated = true;
    }
}
