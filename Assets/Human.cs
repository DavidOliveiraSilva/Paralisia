using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
	public GameObject player;
	public bool patrol;
	public int currentPosition = 0;
	public float offPosition = 0.2f;
	public float timeToWait;
	private float wait;
	public float speed;
	private Rigidbody2D rb;
	public Vector2[] patrulha;
	void Awake(){
		player = GameObject.Find ("Tyler");
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
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

		if (IsSeeingThePlayer ()) {
			patrol = false;
		} else {
			
			float dx = transform.position.x - patrulha [currentPosition].x;
			float dy = transform.position.y - patrulha [currentPosition].y;
			float angle = Mathf.Atan2 (-dy, -dx);
			print (angle);
			rb.velocity = new Vector2 (speed * Mathf.Cos (angle), speed * Mathf.Sin (angle));
			if (CheckPoint (currentPosition)) {
				currentPosition = (currentPosition + 1) % patrulha.Length;
				wait = timeToWait;
			}
		}
	}

	public bool IsSeeingThePlayer(){
		Vector2 humanPos = new Vector2(transform.position.x, transform.position.y);
		Vector2 tylerPos = new Vector2(player.transform.position.x, player.transform.position.y);
		RaycastHit2D ray = Physics2D.Linecast(humanPos, tylerPos, 9);
		if(ray.collider == null && ray.collider.tag == "Player"){
			return true;
		}
		return false;
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
