using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAni : MonoBehaviour {
	private Animator ani;
	private Human hm;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public bool dead = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		hm = GetComponent<Human> ();
		ani = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Mathf.Abs(rb.velocity.x)>0 || Mathf.Abs(rb.velocity.y)>0 ){
			ani.SetBool("Stand", false);
		}else {
			ani.SetBool("Stand", true);
		}
		if (hm.IsSeeingThePlayer ()) {
			ani.SetBool ("Stand", true);
			if (hm.player.transform.position.x < transform.position.x) {
				sr.flipX = true;
				if (hm.hasArm) {
					hm.FlipArm (true);
				}
			}
			if (hm.player.transform.position.x > transform.position.x) {
				sr.flipX = false;
				if (hm.hasArm) {
					hm.FlipArm (false);
				}
			}
		}
		if (rb.velocity.x < 0) {
			sr.flipX = true;
			if (hm.hasArm) {
				hm.FlipArm (true);
			}
		}
		if (rb.velocity.x > 0) {
			sr.flipX = false;
			if (hm.hasArm) {
				hm.FlipArm (false);
			}
		}
	}

}
