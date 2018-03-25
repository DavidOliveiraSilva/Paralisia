using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour {
	private SpriteRenderer sr;
	private Color orig;
	private float timing = 0;
	private float amount = 0;
	public float time;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		orig = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
		timing += Time.deltaTime;
		if(timing > time){
			amount += Time.deltaTime * 0.6f;
			sr.color = new Color (orig.r, orig.g, orig.b, Mathf.Min (amount, 1.0f));
		}
	}
}
