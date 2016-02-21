using UnityEngine;
using System.Collections;

public class MeleeEnemy : Enemy {

    // Fields
    private bool charging;
    private bool windingUp;
    private bool targetExists;
    private float chargeEndTime;
    private float windUpEndTime;
    private int nextUpdate;
    protected float moveSpeed;
    protected float windUpTime;
    protected int ticksToUpdate;
    private Vector2 currentVelocity;

    // Public
    public float speed = 80.0f;

    // Use this for initialization
    protected new void Start ()
    {
        // Call the base (Enemy) class's Start method.
        base.Start();
        charging = false;
        targetExists = false;
        windingUp = false;
        //Initialized meaningless values
        chargeEndTime = 0f;
        windUpEndTime = 0f;
        nextUpdate = 5;
    }
	
	// Fixed update is called on a regular schedule
	protected void FixedUpdate () {
        meleeUpdateRoutine();
        chargeRoutine();
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
                charging = false;
                gameObject.GetComponent<Animator>().SetBool("isCharging", false);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

            }
            // Number of updates until the next update.
            nextUpdate = ticksToUpdate;
        }
        else
        {
            nextUpdate -= 1;
        }
    }


    // Run every FixedUpdate tick
    private void chargeRoutine()
    {
        // If there is a target
        if (isTarget())
        {
            // and we're not in the middle of charging
            if (!isCharging())
            {
                // then start charging.
                startCharge();
            }
        }

        // If we have started charging
        if (isCharging())
        {
            // Check to see if we're still winding up for the charge
            if (!isWindingUp())
            {
                charge();
            }
            // If the charge has reached the target coordinates
            if (this.gameObject.GetComponent<Transform>().position == getTargetCoordinates())
            {
                // Then we are no longer charging, but we will begin checking for a target again the
                // next run-through of the update routine.
                this.charging = false;
                this.targetExists = false;
                gameObject.GetComponent<Animator>().SetBool("isCharging", false);
            }
        }
    }

    // Start the charging procedure!
    private void startCharge()
    {
        charging = true;
        windingUp = true;
        windUpEndTime = Time.time + windUpTime;
        gameObject.GetComponent<Animator>().SetBool("isCharging", true);
    }

    // Charge towards the target coordinates
    private void charge()
    {
        // Get the next position and move towards it.
        Vector3 target = getTargetCoordinates();
        Vector3 vectorToTarget = target - transform.position;
        vectorToTarget = vectorToTarget.normalized;
        //transform.position = Vector2.MoveTowards(this.gameObject.GetComponent<Transform>().position,
        //    getTargetCoordinates(), (Time.fixedDeltaTime * speed));
        currentVelocity = new Vector2(vectorToTarget.x, vectorToTarget.y)
            * speed;
        gameObject.GetComponent<Rigidbody2D>().velocity = currentVelocity;
        gameObject.GetComponent<Rigidbody2D>().AddForce(currentVelocity);
        //this.gameObject.GetComponent<Transform>().Translate(nextPosition);
        //currentVelocity = new Vector2(gameObject.GetComponent<Transform>().up.x, gameObject.GetComponent<Transform>().up.y)
        //    * SPEED;
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = currentVelocity;
    }

    // Getter for charging
    private bool isCharging()
    {
        return charging;
    }

    // Getter for wind-up of charge
    private bool isWindingUp()
    {
        // If we're currently winding up
        if (windingUp)
        {
            // Check to see if the windup should finish
            if (Time.time >= windUpEndTime)
            {
                windingUp = false;
            }
        }
        return windingUp;
    }

    // Getter for targetExists
    public bool isTarget()
    {
        return targetExists;
    }

}
