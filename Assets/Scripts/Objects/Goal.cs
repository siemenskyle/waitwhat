using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    // Fields
    private int playersInGoal;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // If it is an Actor, then interact with it
            advanceToNextLevel();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            // Decrement the number of players in the goal region.
            playersInGoal -= 1;
        }
    }

    // Use this for initialization
    void Start () {
        playersInGoal = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Advance to the next level
    public void advanceToNextLevel()
    {
        // Since the goal has been interacted with, we then move to the next level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
