using UnityEngine;
using System.Collections;

public class HumanClearGood : MonoBehaviour {

	public GameObject checks;

	private int frameCount;

	void Start () {
		frameCount = 0;
	}
	void OnTriggerStay2D(Collider2D other){
		//if( other.isTrigger )
		//	checks.GetComponent<ParTransferGood> ().amClear = true;
		//else
			checks.GetComponent<ParTransferGood> ().amClear = false;

	}

	void OnTriggerExit2D(Collider2D other){
		checks.GetComponent<ParTransferGood> ().amClear = true;
	}

	void Update(){
		this.transform.position = checks.transform.position;


	}
}
