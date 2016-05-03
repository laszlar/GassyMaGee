using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

    public int sizeX;
    public GameObject plankPrefab;

    void Update ()
    {
        Generate();
    }
    public void Generate ()
    {
        for (int x = 0; x < sizeX; x++)
            Instantiate(plankPrefab, new Vector2(x * 0.5f, 0f), Quaternion.identity);
    }

   /*void CreatePlanks (int x)
    {
        GameObject plankPrefab = Instantiate(plankPrefab) as GameObject;
        plankPrefab.name = "Plank " + x;
        plankPrefab.transform.parent = transform;
        plankPrefab.transform.localPosition = new Vector2(x - sizeX * 0.5f + 0.5f, 0f);
    }*/

}
