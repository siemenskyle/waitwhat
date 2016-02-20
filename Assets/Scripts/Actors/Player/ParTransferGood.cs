using UnityEngine;
using System.Collections;

public class ParTransferGood : MonoBehaviour {

	private GameObject partner;
	public int player;
	public bool start;
	public GameObject check;
	public bool amClear;
	public bool partnerClear;

	// Use this for initialization
	void Start () {
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("player");
		foreach (GameObject playOb in temp) {
			if (playOb.GetComponent<ParTransferGood> ().player == player) {
				partner = playOb;
			}
		}
		if (start) {
			this.GetComponent<BoxCollider2D> ().enabled = true;
			partner.transform.parent = this.transform;
			this.transform.parent = null;
			check.transform.parent = this.transform;
			partnerClear = partner.GetComponent<ParTransferGood> ().check.transform.parent = this.transform;

		} else {
			this.GetComponent<BoxCollider2D> ().enabled = false;
		}
		amClear = true;

	
	}
	
	// Update is called once per frame
	void Update () {

		bool switchPersons = Input.GetKeyDown (KeyCode.Space);
		partnerClear = partner.GetComponent<ParTransferGood> ().amClear;

		if (switchPersons) {
			if (this.GetComponent<BoxCollider2D> ().enabled == true) {
				this.transform.parent = partner.transform;
				this.GetComponent<BoxCollider2D> ().enabled = false;
			} else {
			
				this.GetComponent<BoxCollider2D> ().enabled = true;
				this.transform.parent = null;
				check.transform.parent = this.transform;
				partnerClear = partner.GetComponent<ParTransferGood> ().check.transform.parent = this.transform;
			}
		}


	
	}
}
