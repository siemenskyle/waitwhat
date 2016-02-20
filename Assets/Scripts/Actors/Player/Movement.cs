using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int movespeed;
	public KeyBindings keys;

	// Use this for initialization
	void Awake () {
		keys = GetComponent<KeyBindings> ();
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis (keys.getXAxis());

		float y = Input.GetAxis (keys.getYAxis());


		if ((x != 0 || y != 0) && this.transform.parent == null && this.GetComponent<Collider2D>().isTrigger == false) {
			transform.Translate(Vector3.right * movespeed * Time.fixedDeltaTime * x + Vector3.up * movespeed * Time.fixedDeltaTime * y);

		}

	}
}
