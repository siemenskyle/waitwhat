using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, Actor {

	private bool alive;

	GameObject player1;
	GameObject player2;

	// Use this for initialization
	void Start () {
		this.alive = true;
		//TODO: Find players
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Getter for 'alive' field
	bool isAlive(){
		return this.alive;
	}

	// Setter for the 'alive' field
	void die(){
		alive = false;
		//Destroy(this.gameObject);
	}
}
