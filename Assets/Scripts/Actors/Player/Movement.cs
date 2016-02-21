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

		if (x > 0) {
			this.GetComponent<Animator> ().SetBool ("right", true);
			this.GetComponent<Animator> ().SetBool ("left", false);
		} else if (x < 0) {
			this.GetComponent<Animator> ().SetBool ("left", true);
			this.GetComponent<Animator> ().SetBool ("right", false);
		} else {
			this.GetComponent<Animator> ().SetBool ("left", false);
			this.GetComponent<Animator> ().SetBool ("right", false);
		}

		if (y > 0) {
			this.GetComponent<Animator> ().SetBool ("up", true);
			this.GetComponent<Animator> ().SetBool ("down", false);
		} else if (y < 0) {
			this.GetComponent<Animator> ().SetBool ("up", true);
			this.GetComponent<Animator> ().SetBool ("down", false);
		} else {
			this.GetComponent<Animator> ().SetBool ("up", false);
			this.GetComponent<Animator> ().SetBool ("down", false);
		}

		if ((x != 0 || y != 0) && this.transform.parent == null && this.GetComponent<Collider2D>().isTrigger == false) {
			transform.Translate(Vector3.right * movespeed * Time.fixedDeltaTime * x + Vector3.up * movespeed * Time.fixedDeltaTime * y);

		}

	}
}
