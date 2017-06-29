using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroyer : MonoBehaviour
{
    //public bool move;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Wave")
        {
            Vector2 pos = collision.transform.position;
            pos.x += 1.526f;
            collision.transform.position = pos;
        }
        */
    }


            /*
            Destroy(coll.gameObject);
            if (WaveSpawner.Waves0.Count != 0 || WaveSpawner.Waves1.Count != 0 || WaveSpawner.Waves2.Count != 0 ||
                WaveSpawner.Waves3.Count != 0)
            {
                WaveSpawner.Waves0.RemoveAt(0);
                WaveSpawner.Waves1.RemoveAt(0);
                WaveSpawner.Waves2.RemoveAt(0);
                WaveSpawner.Waves3.RemoveAt(0);
            }
            
            move = true;
            */



    /*
public void OnTriggerEnter2D(Collider2D collision)
{
    float widthOfObject = ((BoxCollider2D)collision).size.x;


    if (collision.name == "WaveChunk" || collision.name == "WaveChunk2" || collision.name == "WaveChunk3" 
        || collision.name == "WaveChunk4" || collision.name == "WaveChunk5")
    {
        Vector2 actualPos = collision.transform.position;
        actualPos.x += widthOfObject;
        collision.transform.position = actualPos;
    }


    if (collision.gameObject.tag == "Wave")
    {
        Vector2 actualPos = collision.transform.position;
        actualPos.x += widthOfObject;
        collision.transform.position = actualPos;
    }
}
    */
}
