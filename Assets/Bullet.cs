using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float angle;
	private Rigidbody2D rb;
	public float force;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(force * Mathf.Cos (angle), force * Mathf.Sin (angle)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
