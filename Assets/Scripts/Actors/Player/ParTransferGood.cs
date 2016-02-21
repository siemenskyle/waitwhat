using UnityEngine;
using System.Collections;

public class ParTransferGood : MonoBehaviour {

	private KeyBindings keys;

	public GameObject partner;
	public int player;
	public bool start;
	public GameObject check;
	public bool amClear;
	public bool partnerClear;


	public float xdistPart;
	public float ydistPart;
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

			xdistPart = partner.GetComponent<Transform> ().localPosition.x;
			ydistPart= partner.GetComponent<Transform> ().localPosition.y;

		} else {
			this.GetComponent<Collider2D> ().enabled = false;
			xdistPart = this.transform.localPosition.x;
			ydistPart = this.transform.localPosition.y;
		}
		amClear = true;

	
	}
	
	// Update is called once per frame
	void Update () {

		bool switchPersons = Input.GetButtonDown (keys.getSwapEntity());
		partnerClear = partner.GetComponent<ParTransferGood> ().amClear;

		float x = Input.GetAxis (keys.getXAxis());
		float y = Input.GetAxis (keys.getYAxis());

		//assure that the space between the two characters is as it should be 
		if (start && this.transform.parent == null) {
			partner.GetComponent<Transform> ().localPosition = (new Vector3 (xdistPart, ydistPart, 0f));
		} else if (!start && this.transform.parent == null) {
			partner.GetComponent<Transform> ().localPosition = -(new Vector3 (xdistPart, ydistPart, 0f));
		}



		//While moving make all the clears false, no switching
		if (!((x > -0.5 && x < 0.5) ||( y  >-0.5 && y < 0.5 ))) {
			amClear = false;
			partnerClear = false;
			partner.GetComponent<ParTransferGood> ().amClear = false;
			partner.GetComponent<ParTransferGood> ().partnerClear = false;
		}


		// if they are clear be transparent, otherwise be black
		if (amClear && this.GetComponent<Collider2D> ().enabled == false) {
			this.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
		} else if (!amClear && this.GetComponent<Collider2D> ().enabled == false ) {
			this.GetComponent<SpriteRenderer> ().color = Color.black;
		} else {
			this.GetComponent<SpriteRenderer> ().color = new Color(1f,1f,1f,1f);
		}


		if (switchPersons && x == 0 && y == 0 ) {
			if (this.GetComponent<Collider2D> ().enabled == true && partnerClear) {
				this.transform.parent = partner.transform;
				this.GetComponent<Collider2D> ().enabled= false;
				this.GetComponent<SpriteRenderer> ().color = new Color(1f,1f,1f,0.5f);
				this.amClear = true;
			} else if (this.GetComponent<Collider2D> ().enabled == false && amClear) {
			
				this.GetComponent<Collider2D> ().enabled = true;
				this.transform.parent = null;
				check.transform.parent = this.transform;
				partnerClear = partner.GetComponent<ParTransferGood> ().check.transform.parent = this.transform;
				partner.transform.parent = this.transform;
				this.GetComponent<SpriteRenderer> ().color = new Color(1f,1f,1f,1f);
			}
		}


	
	}
}
