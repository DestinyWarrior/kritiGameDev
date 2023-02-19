using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool state = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("ground"))
        {
            state = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        state = false;
    }
}
