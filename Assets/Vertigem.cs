using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertigem : MonoBehaviour {
	private GameObject player;
	private SpriteRenderer first;
	private SpriteRenderer second;
	private SpriteRenderer third;
	private float division;
	void Awake(){
		player = GameObject.Find ("Tyler");
	}
	// Use this for initialization
	void Start () {
		first = GameObject.Find ("Vertigem1").GetComponent<SpriteRenderer>();
		second = GameObject.Find ("Vertigem2").GetComponent<SpriteRenderer>();
		third = GameObject.Find ("Vertigem3").GetComponent<SpriteRenderer>();
		division = player.GetComponent<Player> ().maxDesireForMeat / 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float desire = player.GetComponent<Player> ().GetDesireForMeat ();
		first.color = new Color (first.color.r, first.color.g, first.color.b, Mathf.Min (desire / division, 1.0f));
		if (desire > division) {
			second.color = new Color (second.color.r, second.color.g, second.color.b, Mathf.Min ((desire - division) / division, 1.0f));
		}
		if (desire > division*2) {
			third.color = new Color (third.color.r, third.color.g, third.color.b, Mathf.Min ((desire - division*2) / division, 1.0f));
		}
	}
}
