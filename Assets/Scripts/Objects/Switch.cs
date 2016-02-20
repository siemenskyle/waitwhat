using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    // Fields
    private bool active = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the triggering object is an Actor
        if (other.gameObject.GetComponent<Human>() != null)
        {
            toggle();
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
