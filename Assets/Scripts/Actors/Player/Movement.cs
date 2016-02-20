using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int movespeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal");

		float y = Input.GetAxis ("Vertical");


		if ((x != 0 || y != 0) && this.transform.parent == null && this.GetComponent<BoxCollider2D>().isTrigger == false) {
			transform.Translate(Vector3.right * movespeed * Time.fixedDeltaTime * x + Vector3.up * movespeed * Time.fixedDeltaTime * y);

		}

	}
}
