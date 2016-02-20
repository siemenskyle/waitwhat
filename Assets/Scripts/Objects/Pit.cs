using UnityEngine;
using System.Collections;

public class Pit : MonoBehaviour, Object {

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

    // Interact based on Actor-Pit interaction
    public void interact(Actor interactor)
    {
        // Make the Actor interacting with the pit die!
        interactor.die();
    }
}
