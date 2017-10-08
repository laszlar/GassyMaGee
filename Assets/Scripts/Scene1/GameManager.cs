using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Items that pop up unnecessarily
    GameObject kettleLauncher;
    GameObject fattyLauncher;
    GameObject bombLauncher;

    GameObject kettle;
    GameObject fatty;
    GameObject bomb;
    //=============================//

    //Player variables
    GameObject player;
    PlayerMovement playerScript;

    //Enemy and Object variables
    GameObject enemy;
    GameObject[] enemyTag;
    GameObject[] bombTag;
    GameObject backGround;
    GameObject[] bGTag;

    private void Start()
    {
        //Find those items on Start
        kettleLauncher = GameObject.Find("KettleLaunching");
        fattyLauncher = GameObject.Find("FattyCannon");
        bombLauncher = GameObject.Find("BombCannon");
        //==============================================//

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

        
    }

	void Update () {
        //Logic that destroys unnecessary items.
        if (kettleLauncher.activeInHierarchy || fattyLauncher.activeInHierarchy || bombLauncher.activeInHierarchy)
        {
            return;
        }
        else
        {
            //find the game objects that are in the heirarchy
            kettle = GameObject.Find("Kettle(Clone)");
            fatty = GameObject.Find("HeftyWoman(Clone)");
            bomb = GameObject.Find("Bomb(Clone)");

            //and then destroy them, as they're not supposed to be there
            Destroy(kettle);
            Destroy(fatty);
            Destroy(bomb);
        }
        //=================================================================//

        //This is the logic for finding all enemies and telling them 
        //to speed up or slow down based on player's condition.
        if (playerScript.parachuteEnabled)
        {
            enemyTag = GameObject.FindGameObjectsWithTag("Enemy");
            bombTag = GameObject.FindGameObjectsWithTag("Bomb");
            bGTag = GameObject.FindGameObjectsWithTag("Background");

            foreach (GameObject enemy in enemyTag)
            {
                enemy.SendMessage("SlowDown");
                print("slow down enemy");
            }

            foreach (GameObject bomb in bombTag)
            {
                bomb.SendMessage("SlowDown");
            }

            foreach (GameObject backGround in bGTag)
            {
                backGround.SendMessage("SlowDown");
            }
        }
        else
        {
            return;
        }

        if (playerScript.bananaEnabled)
        {      
            enemyTag = GameObject.FindGameObjectsWithTag("Enemy");
            bombTag = GameObject.FindGameObjectsWithTag("Bomb");

            
            foreach (GameObject enemy in enemyTag)
            {
                enemy.SendMessage("SpeedUp");
            }

            foreach (GameObject bomb in bombTag)
            {
                bomb.SendMessage("SpeedUp");
            }
        }
        else
        {
            return;
        }
	}
}
