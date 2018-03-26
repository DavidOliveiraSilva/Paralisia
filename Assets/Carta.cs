using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour {
	private CartaPr carta;
	// Use this for initialization
	void Start () {
		carta = GetComponentInChildren<CartaPr> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			if (Input.GetButtonDown("Fire2")) {
				ToggleCarta ();
			}
		}
	}
	void ToggleCarta(){
		if (carta.gameObject.GetComponent<SpriteRenderer> ().enabled) {
			carta.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			carta.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}

	}
}
