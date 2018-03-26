using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
	public GameObject player;
	public bool patrol;
	public int currentPosition = 0;
	public float offPosition = 0.2f;
	public float timeToWait;
	public float wait;
	public float speed;
	private Rigidbody2D rb;
	public float aimAccuracy;
	public GameObject Bullet;
	public float fireDelay;
	private float lastFire;
	public Vector2[] patrulha;
	public bool hasGun;
	public GameOver BloodSplash;
	private GameObject Arm;
	private GameObject shoulder;
	public bool hasArm = false;
	public AudioSource ads;
	private bool sawplayer = false;
	void Awake(){
		player = GameObject.Find ("Tyler");
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		ads = GetComponent<AudioSource> ();
		if (gameObject.GetComponentInChildren<Arm> () != null) {
			hasArm = true;
			Arm = gameObject.GetComponentInChildren<Arm> ().gameObject;
			shoulder = gameObject.GetComponentInChildren<Shoulder> ().gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hasArm) {
			Arm.transform.localPosition = new Vector3 (Arm.transform.localPosition.x, shoulder.transform.localPosition.y, Arm.transform.localPosition.z);
		}
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
			
			if (hasGun) {
				float dx = transform.position.x - player.transform.position.x;
				float dy = transform.position.y - player.transform.position.y;
				float angle = Mathf.Atan2 (-dy, -dx) + Random.Range(-aimAccuracy, aimAccuracy);
				if (Time.time - lastFire > fireDelay) {
					Arm.transform.rotation = Quaternion.AngleAxis ((angle + Mathf.PI/2.0f) * Mathf.Rad2Deg, Vector3.forward);
					Vector3 pos = Arm.GetComponentInChildren<Gun>().transform.position;
					Fire (angle, pos);
					lastFire = Time.time;
				}
			}
		} else {
			if (hasArm) {
				Arm.transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
			}
			float dx = transform.position.x - patrulha [currentPosition].x;
			float dy = transform.position.y - patrulha [currentPosition].y;
			float angle = Mathf.Atan2 (-dy, -dx);
			rb.velocity = new Vector2 (speed * Mathf.Cos (angle), speed * Mathf.Sin (angle));
			if (CheckPoint (currentPosition)) {
				currentPosition = (currentPosition + 1) % patrulha.Length;
				rb.velocity = new Vector2 (0, 0);
				wait = timeToWait;
			}
		}
	}

	public bool IsSeeingThePlayer(){
		
		if (!sawplayer) {
			ads.Play ();
		}
		sawplayer = true;
		Vector2 humanPos = new Vector2(transform.position.x, transform.position.y);
		Vector2 tylerPos = new Vector2(player.transform.position.x, player.transform.position.y);
		RaycastHit2D ray = Physics2D.Linecast(humanPos, tylerPos, 9);
		if(ray.collider == null){
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
	void Fire(float angle, Vector3 pos){
		

		GameObject bullet = Instantiate (Bullet);
		bullet.transform.position = new Vector3(transform.position.x + Mathf.Cos(angle), transform.position.y + Mathf.Sin(angle), transform.position.z);
		bullet.transform.position = pos;
		bullet.GetComponent<Bullet>().angle = angle;
		//bullet.GetComponent<Rigidbody2D>().velocity = new Vector2 (bulletSpeed * Mathf.Cos (angle), bulletSpeed * Mathf.Sin (angle));

	}
	public void FlipArm(bool flip){
		Arm.GetComponent<SpriteRenderer> ().flipX = flip;
		if (flip && Arm.transform.localPosition.x < 0) {
			Arm.transform.localPosition = new Vector3 (-Arm.transform.localPosition.x, Arm.transform.localPosition.y, Arm.transform.localPosition.z);
		}
		if (!flip && Arm.transform.localPosition.x > 0) {
			Arm.transform.localPosition = new Vector3 (-Arm.transform.localPosition.x, Arm.transform.localPosition.y, Arm.transform.localPosition.z);
		}
	}
}
