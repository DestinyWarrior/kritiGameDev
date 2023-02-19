using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject savedPlayerState;
    GameObject[] savedObjects;
    bool isActive;
    private void Start()
    {
        isActive = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActive)
        {
            isActive = true;
            //copy player Data
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerMain pm = player.GetComponent<PlayerMain>();
            pm.curCheckpoint = this.gameObject;

            savedPlayerState = Instantiate(player, this.gameObject.transform);
            savedPlayerState.tag = "SaveState";
            savedPlayerState.SetActive(false);

            //copy breakable objects data
            GameObject[] objList = GameObject.FindGameObjectsWithTag("Breakable");
            savedObjects = objList;
            for(int i=0;i<objList.Length;i++)
            {
                savedObjects[i] = Instantiate(objList[i], this.gameObject.transform);
                savedObjects[i].tag = "SaveState";
                savedObjects[i].SetActive(false);
            }
        }
        //can add animation and sprite for active flag
    }
    public void Respawn()
    {
        //destroy all current objects
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Object.Destroy(player);

        GameObject[] objList = GameObject.FindGameObjectsWithTag("Breakable");
        foreach(var obj in objList)
        {
            Object.Destroy(obj);
        }

        //restore from save state
        foreach(var obj in savedObjects)
        {
            obj.tag = "Breakable";
            obj.SetActive(true);
        }

        savedPlayerState.tag = "Player";
        savedPlayerState.transform.position = gameObject.transform.position+new Vector3(0,1,0);
        savedPlayerState.transform.parent = null;
        savedPlayerState.name = "Player";
        isActive = false;
        savedPlayerState.SetActive(true);
    }
}
