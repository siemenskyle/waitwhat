using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {

	public int inGoal;

	// Use this for initialization
	void Start () {
		inGoal = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (inGoal == 2)
			advanceToNextLevel ();
	}


	// Advance to the next level
	public void advanceToNextLevel()
	{
		// Since the goal has been interacted with, we then move to the next level.
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
