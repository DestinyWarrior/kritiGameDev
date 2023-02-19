using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide hua");
        Destroy(gameObject);
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
