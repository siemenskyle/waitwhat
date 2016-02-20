using UnityEngine;
using System.Collections;

public class ParentTransfer : MonoBehaviour {


	public GameObject top; 
	public GameObject left; 
	public GameObject right; 
	public GameObject bottom; 

	public GameObject topCheck;
	public GameObject rightCheck;
	public GameObject leftCheck;
	public GameObject bottomCheck;

	// Use this for initialization
	public bool topCol;
	public bool rightCol;
	public bool leftCol;
	public bool botCol;

	void Start () {
		partrans ();
		topCol =true;
		rightCol = true;
		leftCol = true;
		botCol = true;
	}
	
	// Update is called once per frame
	void Update () {
		//not to self, fix spawning in problem with using on trigger stay to check to see if it is currently over lapping 
		// and then use on trigger exit to signal the ability to do stuff

		bool t = Input.GetKeyDown ("t");
		bool f = Input.GetKeyDown ("f");
		bool g = Input.GetKeyDown ("g");
		bool h = Input.GetKeyDown ("h");

		float x = Input.GetAxis ("Horizontal");

		float y = Input.GetAxis ("Vertical");

		float total = Mathf.Abs (x) + Mathf.Abs (y);
		if (t && topCol && total ==0) {
			transform.Translate(Vector3.left*0);
			left.transform.SetParent (top.transform);
			bottom.transform.SetParent (top.transform);
			right.transform.SetParent (top.transform);
			top.transform.SetParent (null);
			partrans ();
		} else if (f && leftCol && total == 0){
			transform.Translate(Vector3.left*0);
			left.transform.SetParent (null);
			bottom.transform.SetParent (left.transform);
			right.transform.SetParent (left.transform);
			top.transform.SetParent (left.transform);

			partrans ();
		}else if (g && botCol && total ==0){
			transform.Translate(Vector3.left*0);
			left.transform.SetParent (bottom.transform);
			bottom.transform.SetParent (null);
			right.transform.SetParent (bottom.transform);
			top.transform.SetParent (bottom.transform);
			partrans ();
		} else if (h && rightCol && total == 0){
			transform.Translate(Vector3.left*0);
			right.transform.SetParent (null);
			left.transform.SetParent (right.transform);
			bottom.transform.SetParent (right.transform);
			top.transform.SetParent (right.transform);
			partrans ();
		}
			
	
	}



	void partrans()
	{
		if (this.transform.parent == null) {
			this.GetComponent<Collider2D>().enabled = true;
			topCheck.transform.parent = this.transform;
			leftCheck.transform.parent = this.transform;
			rightCheck.transform.parent = this.transform;
			bottomCheck.transform.parent = this.transform;
		} else {
			this.GetComponent<Collider2D>().enabled = false;
		}
	}
}
