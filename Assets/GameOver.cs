﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space") || Input.GetKey("escape") || Input.GetKey("return")) {
			SceneManager.LoadScene ("Creditos");
		}
	}
}
