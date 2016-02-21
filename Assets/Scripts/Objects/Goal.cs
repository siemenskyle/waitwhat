using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    // Fields
	public GoalManager manager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // If it is a Player, then interact with it
			manager.inGoal += 1;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // Decrement the number of players in the goal region.
            manager.inGoal -= 1;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
