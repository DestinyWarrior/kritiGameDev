using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed=4f;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector=target.position-transform.position;
        vector.z = 0;

        transform.position += vector *Time.deltaTime * speed;


    }
}
