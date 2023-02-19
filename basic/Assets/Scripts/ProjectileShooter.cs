using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public bool dir = false;
    // shooting interval in seconds
    public float shootingInterval = 2f;
    public float speed = -50;
    //if projectile is gravity affected
    public bool isProjAffected = true;
    // prefab of the projectile
    public GameObject toBeSpawned;
    private float timeElapsed;
    private void Start()
    {
        timeElapsed = shootingInterval;
    }
    private void Update()
    {
        if (timeElapsed > shootingInterval)
        {
            ProjectileSpawner();
            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
    }
    /// <summary>
    /// spawn projectile after shooting interval
    /// </summary>
    /// <returns></returns>
    void ProjectileSpawner()
    {
        //spawn the projectile
        GameObject projectile = Instantiate(toBeSpawned, this.transform);
        Rigidbody2D projrb = projectile.GetComponent<Rigidbody2D>();
        if(dir)
        projrb.velocity = new Vector2(0, speed);
        else
            projrb.velocity = new Vector2(speed, 0);
        if (!isProjAffected)
        {
            projrb.gravityScale = 0;
        }
    }
}
