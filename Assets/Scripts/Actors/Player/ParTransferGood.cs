﻿using UnityEngine;
using System.Collections;

public class ParTransferGood : MonoBehaviour {

	private KeyBindings keys;

	public GameObject partner;
	public int player;
	public bool start;
	public GameObject check;
	public bool amClear;
	public bool partnerClear;

	void Awake ()
	{
		keys = GetComponent<KeyBindings> ();
	}

	// Use this for initialization
	void Start () {
		if (start) {
			this.GetComponent<Collider2D> ().enabled = true;
			partner.transform.parent = this.transform;
			this.transform.parent = null;
			check.transform.parent = this.transform;
			partnerClear = partner.GetComponent<ParTransferGood> ().check.transform.parent = this.transform;

		} else {
			this.GetComponent<Collider2D> ().enabled = false;
		}
		amClear = true;

	
	}
	
	// Update is called once per frame
	void Update () {

		bool switchPersons = Input.GetButtonDown (keys.getSwapEntity());
		partnerClear = partner.GetComponent<ParTransferGood> ().amClear;

		if (switchPersons ) {
			if (this.GetComponent<Collider2D> ().enabled == true && partnerClear) {
				this.transform.parent = partner.transform;
				this.GetComponent<Collider2D> ().enabled= false;
			} else if (this.GetComponent<Collider2D> ().enabled == false && amClear) {
			
				this.GetComponent<Collider2D> ().enabled = true;
				this.transform.parent = null;
				check.transform.parent = this.transform;
				partnerClear = partner.GetComponent<ParTransferGood> ().check.transform.parent = this.transform;
				partner.transform.parent = this.transform;
			}
		}


	
	}
}