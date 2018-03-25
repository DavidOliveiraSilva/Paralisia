using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float angle;
	private Rigidbody2D rb;
	private ParticleSystem ps;
	private CircleCollider2D cc;
	private SpriteRenderer sr;
	public float force;
	public float life;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		ps = GetComponent<ParticleSystem> ();
		cc = GetComponent<CircleCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();
		rb.AddForce (new Vector2(force * Mathf.Cos (angle), force * Mathf.Sin (angle)));
	}
	
	// Update is called once per frame
	void Update () {
		life -= Time.deltaTime;
		if (life < 0) {
			AutoDestroy ();
		}
	}

	public void AutoDestroy(){
		ps.Stop ();
		sr.enabled = false;
		cc.enabled = false;
		Destroy (gameObject, ps.main.startLifetime.constantMax);
	}
}
