using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour, Object {

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the triggering object is an Actor
        if (other.gameObject.GetComponent<Human>() != null)
        {
            // If it is an Actor, then interact with it
            interact(other.gameObject.GetComponent<Human>());
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Interact based on Actor-Goal interaction
    public void interact(Actor interactor)
    {
        //TODO: Perform Goal interaction

    }
}
