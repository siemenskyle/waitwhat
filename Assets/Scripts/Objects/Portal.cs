using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    // Fields
    private float timeToTeleport;
    private GameObject teleportTarget;
    public GameObject exitPortal;

    // Constants
    private const float TELEPORT_CHARGE_TIME = 1.5f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // Begin the teleport countdown
            // and keep track of which human was triggering it
            timeToTeleport = Time.time + TELEPORT_CHARGE_TIME;
			teleportTarget = other.gameObject;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        // If the timer has expired
        if (Time.time >= timeToTeleport)
        {
            // If the triggering object is still the human
            if (other.gameObject == teleportTarget)
            {
				if (other.gameObject.name == "Main" || other.gameObject.name == "Main 2") {
					other.gameObject.GetComponent<Transform>().position = exitPortal.GetComponent<Transform>().position;
				} else if (other.gameObject.name == "Second")
				
				}

			foreach( Transform child in other.transform)
			{
				
                // Teleport the human
				
                teleportTarget = null;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // If the triggering object is the target human
        if (other.gameObject == teleportTarget)
        {
            teleportTarget = null;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
