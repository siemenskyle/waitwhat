using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    // Fields
	public GoalManager manager;
	public SpriteRenderer halfheart;

	private Human playeringoal;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // If it is a Player, then interact with it
			halfheart.color = Color.white;
			playeringoal = other.attachedRigidbody.gameObject.GetComponent<Human> ();
			setingoal (true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // Decrement the number of players in the goal region.
			playeringoal = other.attachedRigidbody.gameObject.GetComponent<Human> ();
			setingoal(false);
			halfheart.color = Color.clear;
        }
		playeringoal = null;
    }

	private void setingoal(bool g){
		if (playeringoal.getPlayerNumber () == playerNumber.PLAYER_1)
			manager.p1InGoal = g;
		else if (playeringoal.getPlayerNumber () == playerNumber.PLAYER_2)
			manager.p2InGoal = g;
	}

    // Use this for initialization
    void Start () {
		halfheart.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
