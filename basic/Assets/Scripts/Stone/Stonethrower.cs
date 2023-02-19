//If You Like Our Content, 
//Than Hit The Subscribe Button :)

using System.Collections;
using UnityEngine;

public class Stonethrower : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private bool isPressed;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float timeToDisable=5f;
    [SerializeField] GameObject target;
    [SerializeField] StoneCollection countChanger;
    private bool notPulled = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        countChanger=target.GetComponent<StoneCollection>();  //taking player's stonecollection component
        springJoint.enabled =false;                         //springjoint bw player and stone is disabled so as player moves the joint doesnt generate kinetic energy
       spriteRenderer.enabled = false;                      //stone should not be visible

    }

    void Update()
    {
        if(notPulled)
        {
            gameObject.transform.position = target.transform.position;
            rb.bodyType = RigidbodyType2D.Kinematic;
         
        }
        
        if(Input.GetAxisRaw("StoneThrow")!=0 && countChanger.stone_count > 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = target.transform.position;
            rb.bodyType = RigidbodyType2D.Kinematic;
            spriteRenderer.enabled = true;
            springJoint.enabled = true;
            
                Invoke("DisableComponent", timeToDisable);
            
        }
        if (isPressed && countChanger.stone_count>0 )
        {
            notPulled = false;
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        countChanger.stone_count--;
        countChanger.stoneCount.text = "Stone:" + countChanger.stone_count;

        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }
    private void DisableComponent()
    {
        gameObject.transform.position = target.transform.position;
        spriteRenderer.enabled = false;
        springJoint.enabled = false;

      
 

    }
    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}



