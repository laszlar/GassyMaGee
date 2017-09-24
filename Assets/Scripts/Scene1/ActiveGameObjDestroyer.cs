using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameObjDestroyer : MonoBehaviour {

    GameObject kettleLauncher;
    GameObject fattyLauncher;
    GameObject bombLauncher;

    GameObject kettle;
    GameObject fatty;
    GameObject bomb;

    private void Start()
    {
        kettleLauncher = GameObject.Find("KettleLaunching");
        fattyLauncher = GameObject.Find("FattyCannon");
        bombLauncher = GameObject.Find("BombCannon");

    }

	void Update () {
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
	}
}
