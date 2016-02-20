using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour, Object {

    // Fields
    private bool active = false;

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
        // Perform switch action
        this.toggle();
    }

    // Toggles the switch's state
    public void toggle()
    {
        this.active = !(this.active);
    }

    // Getters/Setters
    public bool isOn()
    {
        return this.active;
    }

}
