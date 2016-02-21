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
			Debug.Log ("Hey");
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
				Debug.Log ("Got here");
                // Teleport the human
				other.gameObject.GetComponent<Transform>().localPosition.Set(exitPortal.transform.position.x, exitPortal.transform.position.y, exitPortal.transform.position.z);
                //other.gameObject.transform.localPosition.Set(exitPortal.transform.position.x, exitPortal.transform.position.y, exitPortal.transform.position.z);
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
