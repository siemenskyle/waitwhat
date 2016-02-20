using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public SwitchManager manager;

	public enum DoorColor {RED, BLUE, GREEN, YELLOW};
	public DoorColor color;

	// Sprites for open and closed doors
	public Sprite openDoorSprite;
	public Sprite closedDoorSprite;

	private SpriteRenderer spriteRenderer;
	private Collider2D coll;

	// If player is in the open door
	private bool inDoor;

	public void OnTriggerEnter2D(Collider2D other)
	{
		// Check to see if the triggering object is a human
		if (other.gameObject.tag == "Player")
		{
			inDoor = true;
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		// Check to see if the triggering object is a human
		if (other.gameObject.tag == "Player")
		{
			inDoor = false;
		}
	}

	// Use this for initialization
	void Start () {
		//TODO: Find Switch Manager

		spriteRenderer = GetComponent<SpriteRenderer> ();
		coll = GetComponent<Collider2D> ();
	}

	void wasInDoor(){
		if (inDoor);
			// Kill player
		inDoor = false;
	}

	// Update is called once per frame
	void Update () {
		if (getPressed () > 0) {
			spriteRenderer.sprite = openDoorSprite;
			coll.isTrigger = true;
		} else {
			spriteRenderer.sprite = closedDoorSprite;
			coll.isTrigger = false;
			wasInDoor ();
		}
	}

	// returns number of switches currently pressed for this color door
	int getPressed(){
		int pressed = 0;
		switch (color) {
		case DoorColor.BLUE:
			pressed = manager.blue;
			break;
		case DoorColor.GREEN:
			pressed = manager.green;
			break;
		case DoorColor.RED:
			pressed = manager.red;
			break;
		case DoorColor.YELLOW:
			pressed = manager.yellow;
			break;
		default:
			break;
		}
		return pressed;
	}
}
