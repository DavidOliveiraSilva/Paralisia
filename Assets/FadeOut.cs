using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
	private float tempo;
	private SpriteRenderer sr;
	private Color originalColor;
	private Color finalColor;
	private float elapsed = 0;
	private bool run = false;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		originalColor = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (run) {
			elapsed += Time.deltaTime*(1.0f/tempo);
			float e = elapsed;
			float f = 1 - elapsed;
			sr.color = new Color ((originalColor.r * f + finalColor.r * e), (originalColor.g * f + finalColor.g * e), (originalColor.b * f + finalColor.b * e), originalColor.a * f);
		}
	}
	public void Run(float time, Color final){
		tempo = time;
		finalColor = final;
		run = true;
	}

}
