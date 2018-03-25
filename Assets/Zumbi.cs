using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour {
	private Animator ani;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public int currentPosition = 0;
	public float offPosition = 0.2f;
	public float timeToWait;
	public float wait;
	public float speed;
	public Vector2[] patrulha;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		ani = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		//intervalo de cada acao do humano
		wait -= Time.deltaTime;
		if (wait > 0) {
			return;
		}
		if (wait < 0) {
			wait = 0;
		}
		//--------------
		float dx = transform.position.x - patrulha [currentPosition].x;
		float dy = transform.position.y - patrulha [currentPosition].y;
		float angle = Mathf.Atan2 (-dy, -dx);
		rb.velocity = new Vector2 (speed * Mathf.Cos (angle), speed * Mathf.Sin (angle));
		if (CheckPoint (currentPosition)) {
			currentPosition = (currentPosition + 1) % patrulha.Length;
			rb.velocity = new Vector2 (0, 0);
			wait = timeToWait;
		}


		if (Mathf.Abs(rb.velocity.x)>0 || Mathf.Abs(rb.velocity.y)>0 ){
			ani.SetBool("stand", false);
		}else {
			ani.SetBool("stand", true);
		}

		if (rb.velocity.x < 0) {
			sr.flipX = true;
		}
		if (rb.velocity.x > 0) {
			sr.flipX = false;
		}
	}
	public bool CheckPoint(int position){
		if (distance (transform.position, patrulha [position]) < offPosition) {
			return true;
		}
		return false;
	}
	private float distance(Vector2 pos1, Vector2 pos2){
		return Mathf.Sqrt (Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2));
	}
}
