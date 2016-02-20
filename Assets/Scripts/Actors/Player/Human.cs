using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour, Actor {

    // Fields
    private bool alive;
    //TODO: Player Field here for any interactions on the player (i.e. respawn from death)

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isAlive()
    {
        return this.alive;
    }

    public void die()
    {
        //TODO: Implement this
    }

}
