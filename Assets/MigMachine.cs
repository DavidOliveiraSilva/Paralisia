using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigMachine : MonoBehaviour {
	public int herbs = 0;
	private float ratio = 0;
	public GameObject sec;
	private SpriteRenderer secSR;
	private ParticleSystem glow;
	private ParticleSystem.MainModule psmain;
	public GameObject Seringa;
	// Use this for initialization
	void Start () {
		secSR = sec.GetComponent<SpriteRenderer> ();
		glow = GetComponentInChildren<ParticleSystem> ();
		psmain = glow.main;

	}
	
	// Update is called once per frame
	void Update () {
		ratio = herbs / 15.0f;
		secSR.color = new Color (secSR.color.r, secSR.color.g, secSR.color.b, ratio);

		psmain.maxParticles = herbs;
		if (herbs >= 15) {
			herbs = 0;
			GameObject ser = Instantiate (Seringa);
			ser.transform.position = new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z);
		}
	}
	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			if (Input.GetButtonDown("Fire2")) {
				bool success = coll.gameObject.GetComponent<Player> ().TransferHerb ();
				if (success && herbs < 15) {
					herbs += 1;
				}
			}
		}
	}
}
