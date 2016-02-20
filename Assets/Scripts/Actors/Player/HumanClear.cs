using UnityEngine;
using System.Collections;

public class HumanClear : MonoBehaviour {

	public GameObject top; 
	public GameObject left; 
	public GameObject right; 
	public GameObject bottom; 
	public GameObject checks;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (checks == top) {
			top.GetComponent<ParentTransfer>().topCol = false;
			right.GetComponent<ParentTransfer>().topCol = false;
			left.GetComponent<ParentTransfer>().topCol = false;
			bottom.GetComponent<ParentTransfer>().topCol = false;
		} else if (checks == right) {
			right.GetComponent<ParentTransfer>().rightCol = false;
			top.GetComponent<ParentTransfer>().rightCol = false;
			left.GetComponent<ParentTransfer>().rightCol = false;
			bottom.GetComponent<ParentTransfer>().rightCol = false;
		} else if (checks == left) {
			left.GetComponent<ParentTransfer>().leftCol = false;
			top.GetComponent<ParentTransfer>().leftCol = false;
			right.GetComponent<ParentTransfer>().leftCol = false;
			bottom.GetComponent<ParentTransfer>().leftCol = false;
		} else if (checks == bottom) {
			bottom.GetComponent<ParentTransfer>().botCol = false;
			top.GetComponent<ParentTransfer>().botCol = false;
			right.GetComponent<ParentTransfer>().botCol = false;
			left.GetComponent<ParentTransfer>().botCol = false;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (checks == top) {
			top.GetComponent<ParentTransfer>().topCol = true;
			right.GetComponent<ParentTransfer>().topCol = true;
			left.GetComponent<ParentTransfer>().topCol = true;
			bottom.GetComponent<ParentTransfer>().topCol = true;
		} else if (checks == right) {
			right.GetComponent<ParentTransfer>().rightCol = true;
			top.GetComponent<ParentTransfer>().rightCol = true;
			left.GetComponent<ParentTransfer>().rightCol = true;
			bottom.GetComponent<ParentTransfer>().rightCol = true;
		} else if (checks == left) {
			top.GetComponent<ParentTransfer>().leftCol = true;
			right.GetComponent<ParentTransfer>().leftCol = true;
			bottom.GetComponent<ParentTransfer>().leftCol = true;
			left.GetComponent<ParentTransfer>().leftCol = true;
		} else if (checks == bottom) {
			top.GetComponent<ParentTransfer>().botCol = true;
			right.GetComponent<ParentTransfer>().botCol = true;
			left.GetComponent<ParentTransfer>().botCol = true;
			bottom.GetComponent<ParentTransfer>().botCol = true;
		}
	}

}
