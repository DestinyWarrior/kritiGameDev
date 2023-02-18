using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des2jump : MonoBehaviour
{
    private int jump=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {

            if (jump==4)
            { Destroy(gameObject, 0); }
            jump ++;
        }

       
    }
}
