using UnityEngine;
using System.Collections;

public class MeleeEnemy : Enemy {

    private int nextUpdate;

	// Use this for initialization
	void Start ()
    {
        nextUpdate = 0;
    }
	
	// Fixed update is called on a regular schedule
	void FixedUpdate () {
	    
        // Check if the player is in line of sight every so often
        if (nextUpdate <= 0)
        {
            checkLineOfSight();
            nextUpdate = 5;
        }
        else
        {
            nextUpdate -= 1;
        }
	}

    // Checks to see if there are any humans in sight, if there is it returns the nearest one.
    private GameObject checkLineOfSight()
    {
        // Get the list of humans
        GameObject[] humanList = GameObject.FindGameObjectsWithTag("Player");
        float nearestDistance = -1.0f;
        GameObject targetHuman = null;
        // Check to see which ones, if any, are in this enemy's line of sight
        foreach(GameObject h in humanList)
        {
            if (canSeeHuman(h))
            {
                // If this human is the closest so far, then that's the target we'll attack!
                if (nearestDistance == -1.0f || distanceToHuman(h) < nearestDistance)
                {
                    nearestDistance = distanceToHuman(h);
                    targetHuman = h;
                }
            }
        }

        // Return the nearest in-sight human, if there is one. Otherwise return null.
        return targetHuman;
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
