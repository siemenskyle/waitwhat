﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {
	public bool startGame;
	public int level;
	public bool p1InGoal;
	public bool p2InGoal;
	public SpriteRenderer levelcompletedialogue;
    public AudioSource endTheme;


	// Use this for initialization
	void Start () {
		p1InGoal = false;
		levelcompletedialogue.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		if (p1InGoal && p2InGoal) {
			levelcompletedialogue.color = Color.white;
            //advanceToNextLevel ();
            endTheme.PlayOneShot(endTheme.clip, 0.15f);
			Invoke("advanceToNextLevel", 2.2f);
		}
		startGame = Input.GetButtonDown ("SwapEntityP1");
		if (level == 0 && startGame) {
			advanceToNextLevel ();
		}
	}

	public void resetLevel()
	{
		SceneManager.LoadScene(level, LoadSceneMode.Single);
	}


	// Advance to the next level
	void advanceToNextLevel()
	{
		level++;
		// Since the goal has been interacted with, we then move to the next level.
		SceneManager.LoadScene(level, LoadSceneMode.Single);
		//SceneManager.LoadScene(nextLevel);
	}
}
