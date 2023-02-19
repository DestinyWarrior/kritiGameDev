using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public GameObject canva;
    public void Die()
    {
        PlayerMain pm = gameObject.GetComponent<PlayerMain>();
        canva.SetActive(true);
        if(pm.curCheckpoint)
            pm.curCheckpoint.GetComponent<CheckPoint>().Respawn();
    }
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("traps"))
        {
            Die();
        }
    }
}
