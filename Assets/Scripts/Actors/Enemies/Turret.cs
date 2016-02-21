using UnityEngine;
using System.Collections;

public class Turret : Enemy {

	// Type of firing of turret
	public enum fireTypeEnum {FIRE_WHEN_VISIBLE, FIRE_AT_INTERVAL};
	public fireTypeEnum fireType;

    // The prefab of the bullet
    public GameObject bullet;

    // Firing properties
    private float cooldown;
    private const float CD_DURATION = 1.5f;

	// Rate of fire, used for FIRE_AT_INTERVAL
	public float firerate;
	private delegate void FireDelagate(); 
	private FireDelagate fireDelegate;

	// Use this for initialization
	protected new void Start () {
        base.Start();
		if (fireType == fireTypeEnum.FIRE_WHEN_VISIBLE)
			fireDelegate = FireWhenVisible;
		else if (fireType == fireTypeEnum.FIRE_AT_INTERVAL)
			fireDelegate = FireAtInterval;

        //First shot is potentially 1 second after load.
        cooldown = Time.time + 1.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		fireDelegate ();
	}

	// Fire the turret on a set interval
	void FireAtInterval () {
		if(Time.time > cooldown)
        {
            //TODO: Implement this
        }
	}

	// Fire the turrent when visible
	void FireWhenVisible () {
        // If a human is in sight and there is no cooldown active
		if(humanIsInLineOfSight() && Time.time > cooldown)
        {
            /* We are in range, set the animator to reflect this. */
            //enemy.GetComponent<Animator>().SetBool("inRange", true);
            /* Get the target position to shoot bullet at. */
            Vector3 target = getTargetCoordinates() - gameObject.GetComponent<Transform>().position;
            /* Calculate the angle between the cloud and the player. */
            float deltaY, deltaX, angleToPlayer;
            //First get difference between start and end point.
            deltaX = target.x - this.gameObject.transform.position.x;
            deltaY = target.y - this.gameObject.transform.position.y;
            //Now calculate the angle.
            angleToPlayer = Mathf.Atan2(deltaY, deltaX) * 180.0f / Mathf.PI + 90.0f; //+90 is offset for pointing
            /* Create a new bullet to launch at the player. */
            GameObject bulletInstance = Instantiate(bullet, this.transform.position, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
            /* Set the angle of the bullet. */
            bulletInstance.transform.localEulerAngles = new Vector3(0f, 0f, angleToPlayer);
            //target = target.normalized;
            /* Launch the bullet towards the player. (Velocity is set here) */
            //bolt.GetComponent<Rigidbody2D>().velocity = target * 20.0f;
            /* We have used the attack, so set that we are on cooldown. */
            cooldown = Time.time + CD_DURATION;
        }
	}
}
