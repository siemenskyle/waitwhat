﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    // Fields
    private float currentSpeed;
    private Vector2 currentVelocity;
    private Vector3 target;
    private GameObject parentTurret;

    // Constants
    private const float START_SPEED = 0.02f;
    private const float MAX_SPEED = 3.0f;
    private const float ACCELERATION = 0.01f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If this bullet has just hit a shield, then reverse its velocity (bounces off)
        if (other.gameObject.GetComponent<Enemy>() != null && other.gameObject.GetComponent<Enemy>().reflectsProjectiles())
        {
            reverseVelocity();
        }
        else if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Human>().die();
        }
        else if (other.gameObject != parentTurret)
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        // The period for which this bullet will accelerate.
        currentSpeed = START_SPEED;
        currentVelocity = new Vector2(gameObject.GetComponent<Transform>().forward.x, gameObject.GetComponent<Transform>().forward.y)
            * currentSpeed;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = currentVelocity;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        accelerate();
    }

    //Accelerates this object by the acceleration
    private void accelerate()
    {
        if (currentSpeed >= MAX_SPEED)
        {
            currentSpeed = MAX_SPEED;
        }
        else
        {
            currentSpeed = currentSpeed + ACCELERATION;
        }
        //currentVelocity = new Vector2(gameObject.GetComponent<Transform>().forward.x, gameObject.GetComponent<Transform>().forward.y)
        //    * currentSpeed;
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = currentVelocity;
    }

    // Reverse the velocity of the bullet
    private void reverseVelocity()
    {
        // Rotate the bullet's orientation by 180 degrees
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0f, 0f, 180f));
        this.gameObject.GetComponent<Rigidbody2D>().velocity.Set(-1 * this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -1 * this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    // Set the new target coordinates
    public void setTarget(Vector3 targetIn)
    {
        target = targetIn;
    }

    // Set's the turret that is shooting this bullet, necessary for collision detection
    public void setParentTurret(GameObject turret)
    {
        parentTurret = turret;
    }
}