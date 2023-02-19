using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject lever;
    SwitchButton btn;
    bool oldState,flag=false;
    float distance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        btn = lever.GetComponent<SwitchButton>();
        oldState = btn.state;
    }

    // Update is called once per frame
    void Update()
    {
        if(btn.state!=oldState)
        {
            Vector3 v = new Vector3(0, distance, 0);
            if(flag)
                gameObject.transform.position -= v;
            else
                gameObject.transform.position += v;
            flag = !flag;
            oldState = !oldState;
        }
    }
}
