using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    // Fields
    private float timeToTeleport;
    private GameObject teleportTarget;
    public GameObject exitPortal;
	bool used;

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
		used = false;
	}
	
	// Update is called once per frame
	void Update () {
		// If the timer has expired
		if (Time.time >= timeToTeleport && teleportTarget != null && !used)
		{
			// If the triggering object is still the human

			Debug.Log ("exit x, y");
			Debug.Log (exitPortal.transform.position.x);
			Debug.Log (exitPortal.transform.position.y);

			Debug.Log ("partner x, y");
			Debug.Log (teleportTarget.GetComponent<ParTransferGood> ().partner.transform.position.x);
			Debug.Log (teleportTarget.GetComponent<ParTransferGood> ().partner.transform.position.y);

			Debug.Log ("active x, y");
			Debug.Log (teleportTarget.transform.position.x);
			Debug.Log (teleportTarget.transform.position.y);


			teleportTarget.GetComponent<ParTransferGood> ().xdistPart = teleportTarget.GetComponent<ParTransferGood> ().xdistPart - (this.transform.position.x - exitPortal.transform.position.x);
			teleportTarget.GetComponent<ParTransferGood> ().ydistPart = teleportTarget.GetComponent<ParTransferGood> ().ydistPart - (this.transform.position.y - exitPortal.transform.position.y);
			teleportTarget.GetComponent<ParTransferGood> ().partner.GetComponent<ParTransferGood> ().xdistPart = teleportTarget.GetComponent<ParTransferGood> ().xdistPart;
			teleportTarget.GetComponent<ParTransferGood> ().partner.GetComponent<ParTransferGood> ().ydistPart = teleportTarget.GetComponent<ParTransferGood> ().ydistPart;

			teleportTarget.GetComponent<Transform> ().position = exitPortal.transform.position;
				

				// Teleport the human

				teleportTarget = null;
				Destroy (teleportTarget);
				Destroy (this.gameObject);

		}
	
	}
    
}
