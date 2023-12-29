using UnityEngine;

public class pullObject : MonoBehaviour
{
    public float pullForce = 10f; // The force at which the object will be pulled
    public float maxDistance = 10f; // The maximum distance at which the object can be pulled

    private GameObject pulledObject = null; // The object being pulled, set to null initially
    private Vector2 pullDirection = Vector2.zero; // The direction in which the object is being pulled

    private void Update()
    {
        // If there is a pulled object, move it towards the player
        if (pulledObject != null)
        {
            Vector2 playerPosition = transform.position;
            Vector2 objectPosition = pulledObject.transform.position;

            float distance = Vector2.Distance(playerPosition, objectPosition);
            if (distance > maxDistance)
            {
                ReleaseObject();
            }
            else
            {
                pulledObject.GetComponent<Rigidbody2D>().AddForce(pullDirection * pullForce, ForceMode2D.Force);
            }
        }

        // If the player presses a button, try to pull an object towards them
        if (Input.GetButtonDown("Pull"))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, maxDistance);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("pullable"))
                {
                    pulledObject = collider.gameObject;
                    pullDirection = (Vector2)transform.position - (Vector2)pulledObject.transform.position;
                    pullDirection.Normalize();
                    break;
                }
            }
        }

        // If the player releases the button, release the pulled object
        if (Input.GetButtonUp("Pull"))
        {
            ReleaseObject();
        }
    }

    private void ReleaseObject()
    {
        pulledObject = null;
        pullDirection = Vector2.zero;
    }
}

