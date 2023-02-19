using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerHealth ph = player.GetComponent<PlayerHealth>();
            if (ph)
                ph.Die();
            else
                Debug.Log("no  player found on spikes");
        }
    }
}
