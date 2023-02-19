
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class laser : MonoBehaviour
{


    public LineRenderer lineRenderer;
    public Transform laserPosition;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        lineRenderer.SetPosition(0,laserPosition.position);
     /*   if(Input.GetAxisRaw("ray")!=0)
        {
            if(lineRenderer.isVisible==true)
            {
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
        if(hit)
        {*/
            lineRenderer.SetPosition(1,hit.point);
        //}
        //else
        /*{
            lineRenderer.SetPosition(1, transform.right * 100);
        }*/
    }
}