﻿using UnityEngine;
using System.Collections;

public class SinkLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public GameObject sink;
    public float sinkSpawnLocation;


    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the ducks!
    {
        GameObject sinkInst = Instantiate(sink, new Vector2(sinkSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity) as GameObject;
        sinkInst.gameObject.tag = "Enemy";
    }
}