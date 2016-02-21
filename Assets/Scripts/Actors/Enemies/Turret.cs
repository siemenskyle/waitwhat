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

    // Constants
    private const float TURN_SPEED = 2f;

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
        // If a human is in sight
        if(humanIsInLineOfSight())
        {
            Vector3 target = getTargetCoordinates();
            Vector3 vectorToTarget = target - transform.position;
            // -90 degrees due to direction of sprite (it's facing 'upwards')
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90.0f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * TURN_SPEED);
        }
        // If a human is in sight and there is no cooldown active
		if(humanIsInLineOfSight() && Time.time > cooldown)
        {
            Vector3 inFront = transform.rotation * (Vector3.up * 0.65f);
            GameObject bulletInstance = Instantiate(bullet, inFront + this.transform.position, this.transform.rotation) as GameObject;
            bulletInstance.GetComponent<Bullet>().setParentTurret(this.gameObject);
            /* Set the angle of the bullet. */
            //bulletInstance.GetComponent<Rigidbody2D>().velocity = bulletInstance.GetComponent<Transform>().forward * 3.0f;
            //Debug.Log(bulletInstance.GetComponent<Transform>().forward.ToString());
            /* We have used the attack, so set that we are on cooldown. */
            cooldown = Time.time + CD_DURATION;
        }
	}
}
