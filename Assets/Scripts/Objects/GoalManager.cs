using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {
	
	public bool p1InGoal;
	public bool p2InGoal;
	public SpriteRenderer levelcompletedialogue;


	// Use this for initialization
	void Start () {
		p1InGoal = false;
		levelcompletedialogue.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		if (p1InGoal && p2InGoal) {
			levelcompletedialogue.color = Color.white;
			advanceToNextLevel ();
		}
	}


	// Advance to the next level
	void advanceToNextLevel()
	{
		// Since the goal has been interacted with, we then move to the next level.
		//SceneManager.LoadScene(nextLevel);
	}
}
