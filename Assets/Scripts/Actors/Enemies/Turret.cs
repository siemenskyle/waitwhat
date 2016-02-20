using UnityEngine;
using System.Collections;

public class Turret : Enemy {

	// Type of firing of turret
	public enum fireTypeEnum {FIRE_WHEN_VISIBLE, FIRE_AT_INTERVAL};
	public fireTypeEnum fireType;

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
	}
	
	// Update is called once per frame
	void Update () {
		fireDelegate ();
	}

	// Fire the turret on a set interval
	void FireAtInterval () {
		//TODO: Implement this
	}

	// Fire the turrent when visible
	void FireWhenVisible () {
		//TODO: implement this
	}
}
