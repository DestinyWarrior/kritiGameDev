using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneCollection : MonoBehaviour
{
    public int stone_count = 0;
    public Text stoneCount;
     
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stonePoints"))
        {
            Destroy(collision.gameObject);
            stone_count++;
            stoneCount.text = "Stone:" + stone_count;

        }
    }
}
