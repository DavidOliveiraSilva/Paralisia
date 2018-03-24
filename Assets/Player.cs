using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D rb;
	public float speed = 1;
	public int maxHP = 5;
	public int HP;
	public float sanity;
	public float desireForMeat;
	public int herbs = 0;
	private bool dead;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			return;
		}
		if (HP <= 0) {
			dead = true;
		}
		//Movimento:
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		if (Mathf.Abs (hor) > 0 || Mathf.Abs (ver) > 0) { //se algum botao direcional estiver pressionado
			float angle = Mathf.Atan2 (ver, hor);
			rb.velocity = new Vector2 (speed * Mathf.Cos (angle)*Mathf.Abs(hor), speed * Mathf.Sin (angle)*Mathf.Abs(ver));
		} else {
			rb.velocity = new Vector2 (0, 0);
		}
	}
	public void TakeDamage(int amount){
		HP = HP - amount;
		if (HP < 0) {
			HP = 0;
		}
	}
}
