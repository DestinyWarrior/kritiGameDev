using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public int health;
    public GameObject curCheckpoint;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        curCheckpoint = null;
        health = 5;
    }

    
}
