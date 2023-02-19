
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camerafollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = transform.position;
        Vector3 vector = target.position - transform.position;
        vector.z = 0;
        Vector3 vector2 = new Vector3(0,0,0);
        vector2.x= vector.x * Time.deltaTime * speed;
        transform.position += vector2;
    }
}