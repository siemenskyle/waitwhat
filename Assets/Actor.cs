using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    // Properties/Fields
    private bool alive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Getter for 'alive' field
    public bool isAlive()
    {
        return this.alive;
    }

    // Setter for the 'alive' field
    public void die()
    {
        this.alive = false;
    }
}
