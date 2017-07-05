using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

    public int numBGPanels = 6;
    private int numCloudPanels = 4;
    public float actualWidth;
    private float bgWidth;
    private float cloudWidth;
    private float waveWidth;
    private GameObject deepOcean0;
    private GameObject deepOcean1;
    private GameObject deepOcean2;
    private GameObject sand0;
    private GameObject sand1;
    private GameObject sand2;

    void Start()
    {
        /*deepOcean0 = GameObject.Find("Deepocean");
        deepOcean1 = GameObject.Find("Deepocean");
        deepOcean2 = GameObject.Find("Deepocean");

        sand0 = GameObject.Find("Sand0");
        sand1 = GameObject.Find("Sand1");
        
        sand2 = GameObject.Find("Sand2");
    */
    }

	void OnTriggerEnter2D (Collider2D collider)
    {
        float widthOfBGObject = ((BoxCollider2D)collider).size.x;

        if (collider.name == "Deepocean" || collider.name == "Deepocean1" || collider.name == "Deepocean2")
        {
            Vector2 actualPos = collider.transform.position;
            actualWidth = widthOfBGObject * 0.3f;
            actualPos.x += actualWidth * (numBGPanels / 2);
            collider.transform.position = actualPos;
        }

        if (collider.name == "subprototype_edificios01_0" || collider.name == "subprototype_dificios01.1_0" || 
            collider.name == "subprototype_edificios02_0" || collider.name == "subprototype_edificios02.1_0" || 
            collider.name == "subprototype_edificios06_0" || collider.name == "subprototype_edificios06.1_0")
        {
            Vector2 bgPos = collider.transform.position;
            bgWidth = widthOfBGObject * 0.25f;
            bgPos.x += bgWidth * numBGPanels;
            collider.transform.position = bgPos;
        }

        if (collider.name == "clouds_0" || collider.name == "clouds_0 (1)" ||
            collider.name == "clouds_0 (2)" || collider.name == "clouds_0 (3)")
        {
            Vector2 cloudPos = collider.transform.position;
            cloudWidth = widthOfBGObject * 0.25f;
            cloudPos.x += cloudWidth * numCloudPanels;
            collider.transform.position = cloudPos;
        }

        if (collider.name == "WaveChunk" || collider.name == "WaveChunk2" ||
            collider.name == "WaveChunk3" || collider.name == "WaveChunk4" ||
            collider.name == "WaveChunk5" || collider.name == "WaveChunk6" ||
            collider.name == "WaveChunk7" || collider.name == "WaveChunk8")
        {
            Vector2 wavePos = collider.transform.position;
            waveWidth = widthOfBGObject;
            wavePos.x += waveWidth * 8;
            collider.transform.position = wavePos;
        }
    }


}
