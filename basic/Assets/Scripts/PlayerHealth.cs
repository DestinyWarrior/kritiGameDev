using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void Die()
    {
        PlayerMain pm = gameObject.GetComponent<PlayerMain>();

        pm.curCheckpoint.GetComponent<CheckPoint>().Respawn();
    }
}
