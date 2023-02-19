using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Transform player;
    public float amount=0.03f;
    public float frequency=25;
    public float shakeTime = 0.3f;
    float curShakeTime = 0;
    float curShakeAngle = 0;
    Vector3 ShakeOffset;
    private void Update()
    {
        if(curShakeTime>0)
        {
            curShakeAngle += Time.deltaTime * 200;
            Vector3 shakeDirecion = Quaternion.Euler(new Vector3(0,0,curShakeAngle
                )) * Vector3.right;
            curShakeTime -= Time.deltaTime;
            float percent = curShakeTime / shakeTime;
            ShakeOffset = shakeDirecion * Mathf.Sin(Mathf.PI * percent * frequency) * amount * percent;
        }
        transform.localPosition = ShakeOffset;
        if(Input.GetMouseButtonDown(0))
        {
            Shake();
        }
    }
    void Shake()
    {
        curShakeTime = shakeTime;
    }
}
