using UnityEngine;
using System.Collections;

public enum playerNumber {PLAYER_1, PLAYER_2};

public class Human : MonoBehaviour, Actor {

    // Fields
    private bool alive;
	public playerNumber playerNum;
    //TODO: Player Field here for any interactions on the player (i.e. respawn from death)

	// Use this for initialization
	void Start () {
        this.alive = true;
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

	public playerNumber getPlayerNumber()
	{
		return playerNum;
	}

}
