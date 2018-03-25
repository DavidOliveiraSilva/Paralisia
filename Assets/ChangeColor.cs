using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
	private SpriteRenderer sr;
	private Color originalColor;
	public float interval;
	private float time;
	public Color[] colorList;
	private int currentColor = 0;
	private float lastChange = 0;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		originalColor = sr.color;
		lastChange = -interval;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time - lastChange > interval) {
			sr.color = colorList [currentColor];
			currentColor = (currentColor + 1) % colorList.Length;	
			lastChange = time;
		}
	}
}
