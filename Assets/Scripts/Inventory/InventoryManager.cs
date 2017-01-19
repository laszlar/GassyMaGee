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

    List <GameObject> inventoryItems = new List<GameObject>();

    private int highScore;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Use this for initialization
    void Start ()
    {
        score = GetComponent<ScoreTracker>();
        paint = GameObject.Find("PaintImage");
        parachute = GameObject.Find("ParachuteImage");
        firstInventorySlot = GameObject.FindGameObjectWithTag("Slot1");
        secondInventorySlot = GameObject.FindGameObjectWithTag("Slot2");
        thirdInventorySlot = GameObject.FindGameObjectWithTag("Slot3");
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }

        firstInventorySlot = inventoryItems[0];
        secondInventorySlot = inventoryItems[1];
        thirdInventorySlot = inventoryItems[2];
        
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
                }
            }  
        }
        else
            return;
    }
}
