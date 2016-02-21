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

		if (Mathf.Abs (x) > Mathf.Abs (y)) {
			this.GetComponent<Animator> ().SetBool ("Moving", true);
			this.GetComponent<Animator> ().SetBool ("Top", false);
			this.GetComponent<Animator> ().SetBool ("Down", false);

			if (x > 0) {
				this.GetComponent<Animator> ().SetBool ("Right", true);
				this.GetComponent<Animator> ().SetBool ("Left", false);
			} else if (x < 0) {
				this.GetComponent<Animator> ().SetBool ("Left", true);
				this.GetComponent<Animator> ().SetBool ("Right", false);
			} else {
				this.GetComponent<Animator> ().SetBool ("Left", false);
				this.GetComponent<Animator> ().SetBool ("Right", false);
			}
		} else {
			this.GetComponent<Animator> ().SetBool ("Moving", true);
			this.GetComponent<Animator> ().SetBool ("Left", false);
			this.GetComponent<Animator> ().SetBool ("Right", false);
			if (y > 0) {
				this.GetComponent<Animator> ().SetBool ("Top", true);
				this.GetComponent<Animator> ().SetBool ("Down", false);
			} else if (y < 0) {
				this.GetComponent<Animator> ().SetBool ("Top", false);
				this.GetComponent<Animator> ().SetBool ("Down", true);
			} else {
				this.GetComponent<Animator> ().SetBool ("Top", false);
				this.GetComponent<Animator> ().SetBool ("Down", false);
			}
		}
		if (x == 0 && y == 0) {
			this.GetComponent<Animator> ().SetBool ("Moving", false);
		}
		if ((x != 0 || y != 0) && this.transform.parent == null && this.GetComponent<Collider2D>().isTrigger == false) {
			transform.Translate(Vector3.right * movespeed * Time.fixedDeltaTime * x + Vector3.up * movespeed * Time.fixedDeltaTime * y);

		}

	}
}
