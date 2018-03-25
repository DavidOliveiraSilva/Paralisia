using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {
	private float timing = 6;
	private SpriteRenderer logo;
	// Use this for initialization
	void Start () {
		logo = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timing -= Time.deltaTime;
		if (timing <= 0) {
			SceneManager.LoadScene ("MenuTitle");
		}
		if (timing > 5) {
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, logo.color.a + Time.deltaTime);
		} else {
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, logo.color.a - Time.deltaTime/5.0f);
		}
	}
}
