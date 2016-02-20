using UnityEngine;
using System.Collections;

public class MeleeEnemy : Enemy {

    // Fields
    private bool targetExists;
    private int nextUpdate;
    private Vector3 currentTarget;
    // Constants
    private const int TICKS_TO_UPDATE = 5;

    // Use this for initialization
    protected new void Start ()
    {
        // Call the base (Enemy) class's Start method.
        base.Start();
        nextUpdate = TICKS_TO_UPDATE;
        targetExists = false;
    }
	
	// Fixed update is called on a regular schedule
	protected void FixedUpdate () {
        meleeUpdateRoutine();
	}

    protected void meleeUpdateRoutine()
    {
        // Check if the player is in line of sight every so often
        if (nextUpdate <= 0)
        {
            // If a target has been found, set flag boolean to true
            // otherwise set the flag to false.
            if (humanIsInLineOfSight())
            {
                targetExists = true;
            }
            else
            {
                targetExists = false;
            }
            // Number of updates until the next update.
            nextUpdate = TICKS_TO_UPDATE;
        }
        else
        {
            nextUpdate -= 1;
        }
    }

    // Checks to see if there are any humans in sight, if there is it returns success.
    // Postcondition: If there is a human in LOS, then the human's position is stored in
    //   'currentTarget', as well, 'targetExists' must be set to true. If there is no
    //   human found, then 'targetExists' must be set to false.
    private bool humanIsInLineOfSight()
    {
        // Get the list of humans
        GameObject[] humanList = GameObject.FindGameObjectsWithTag("Player");
        float nearestDistance = -1.0f;
        bool success = false;
        // Check to see which ones, if any, are in this enemy's line of sight
        foreach(GameObject h in humanList)
        {
            if (canSeeHuman(h))
            {
                // If this human is the closest so far, then that's the target we'll attack!
                if (nearestDistance == -1.0f || distanceToHuman(h) < nearestDistance)
                {
                    nearestDistance = distanceToHuman(h);
                    currentTarget = h.GetComponent<Transform>().position;
                    success = true;
                }
            }
        }

        // Return the nearest in-sight human, if there is one. Otherwise return null.
        return success;
    }

    private bool canSeeHuman(GameObject target)
    {
        // Get which direction the human is from the enemy, cast the ray in that
        // direction to see if the enemy can see the player.
        Vector3 rayDirection = target.GetComponent<Transform>().position - this.gameObject.GetComponent<Transform>().position;
        // If the player is within x units, he can see him.
        // Attempt to cast laser towards player, ignoring the enemies layer.
        string[] layersToHit = new string[2];
        layersToHit[0] = "Player";
        layersToHit[1] = "Default";
        // The length to which this enemy can see
        float length = 20f;
        RaycastHit2D rayHit = Physics2D.Raycast(this.gameObject.GetComponent<Transform>().position, rayDirection, length, LayerMask.GetMask(layersToHit)); // Cast ray
        // If the enemy can see the player, return true, else return false.
        if (rayHit.transform != null && rayHit.transform.gameObject.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Get the distance between this enemy and a target Human
    private float distanceToHuman(GameObject target)
    {
        // The target human's coordinates
        float targetX = target.GetComponent<Transform>().position.x, targetY = target.GetComponent<Transform>().position.y;
        // The enemy's coordinates
        float myX = this.gameObject.GetComponent<Transform>().position.x, myY = this.gameObject.GetComponent<Transform>().position.y;

        // Calculate the distance between the two
        // Equation: sqrt( (x2 - x1)^2  +  (y2 - y1)^2 )
        return Mathf.Sqrt((Mathf.Pow((targetX - myX), 2) + Mathf.Pow((targetY - myY), 2)));
    }
}
