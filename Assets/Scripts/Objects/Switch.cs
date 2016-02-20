using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    // Fields
    public enum switchType { BLUE, RED, GREEN, YELLOW }
    public switchType type;
    public SwitchManager manager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            toggleOn();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Check to see if the triggering object is a human
        if (other.gameObject.tag == "Player")
        {
            toggleOff();
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Toggles the switch's state to on
    public void toggleOn()
    {
        switch (type)
        {
            case switchType.BLUE:
                manager.blue += 1;
                break;
            case switchType.GREEN:
                manager.green += 1;
                break;
            case switchType.RED:
                manager.red += 1;
                break;
            case switchType.YELLOW:
                manager.yellow += 1;
                break;
            default:
                break;
        }
    }

    // Toggle the switch's state to off
    public void toggleOff()
    {
        switch (type)
        {
            case switchType.BLUE:
                manager.blue -= 1;
                break;
            case switchType.GREEN:
                manager.green -= 1;
                break;
            case switchType.RED:
                manager.red -= 1;
                break;
            case switchType.YELLOW:
                manager.yellow -= 1;
                break;
            default:
                break;
        }
    }

}
