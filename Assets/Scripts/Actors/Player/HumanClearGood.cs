﻿using UnityEngine;
using System.Collections;

public class HumanClearGood : MonoBehaviour {

	public GameObject checks;

	void OnTriggerStay2D(Collider2D other){
		checks.GetComponent<ParTransferGood> ().amClear = false;
	}

	void OnTriggerExit2D(Collider2D other){
		checks.GetComponent<ParTransferGood> ().amClear = true;
	}
}