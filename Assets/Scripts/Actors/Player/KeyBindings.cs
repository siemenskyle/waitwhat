using UnityEngine;
using System.Collections;
/**
 * HOW TO USE THIS SCRIPT
 * 		- attatch it to the thing that the movement script is attatched to. 
 * 		- make sure that the thing has a Human script
 * 		- in that movement script, instead of calling the standard input, call this script's
 * 				- getXAxis
 * 				- getYAxis
 * 				- getSwapEntity
 */
public class KeyBindings : MonoBehaviour {

	public Human human;
	private string xAxis;
	private string yAxis;
	private string swapEntity;


	void Awake()
	{
		human = GetComponent<Human> ();
	}

	// Use this for initialization
	void Start () 
	{
		switch (human.getPlayerNumber()) 
		{
			case playerNumber.PLAYER_1:
				xAxis = "HorizontalP1";
				yAxis = "VerticalP1";
				swapEntity = "SwapEntityP1";
				break;
			case playerNumber.PLAYER_2:
				xAxis = "HorizontalP2";
				yAxis = "VerticalP2";
				swapEntity = "SwapEntityP2";
				break;
		}
	}

	string getXAxis ()
	{
		return xAxis;
	}
	string getYAxis()
	{
		return xAxis;
	}
	string getSwapEntity()
	{
		return swapEntity;
	}
}