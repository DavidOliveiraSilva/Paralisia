using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private Rigidbody2D rb;
	public float speed = 1;
	public int maxHP = 5;
	public int HP;
	public float sanity;
	private float desireForMeat = 0;
	public float maxDesireForMeat = 50;
	private float herbEffect = 0;
	public float herbDuration = 10;
	public int herbs = 0;
	private bool dead;
	private bool isZumbi = true;
	private Animator ani;
	public GameObject BloodSplash;
	private GameObject vidahud1;
	private GameObject vidahud2;
	private GameObject vidahud3;
	private GameObject vidahud4;
	private GameObject vidahud5;
	private float interact = 0;
	// Use this for initialization
	void Awake(){
		vidahud1 = GameObject.Find ("vida1");
		vidahud2 = GameObject.Find ("vida2");
		vidahud3 = GameObject.Find ("vida3");
		vidahud4 = GameObject.Find ("vida4");
		vidahud5 = GameObject.Find ("vida5");

	}
	void Start () {
		ani = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		Vidahud();
		if (interact > 0){
			interact -= Time.deltaTime;
			if(interact < 0){
				interact = 0;
			}
		}
		if (herbEffect > 0) {
			herbEffect -= Time.deltaTime;
		} else {
			desireForMeat += Time.deltaTime;
		}
		if (dead) {
			return;
		}
		if (HP <= 0) {
			ani.SetTrigger ("dead");
			dead = true;
			SceneManager.LoadScene ("GameOver");
			return;
		}
		//Movimento:
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		if (Mathf.Abs (hor) > 0 || Mathf.Abs (ver) > 0) { //se algum botao direcional estiver pressionado
			float angle = Mathf.Atan2 (ver, hor);
			rb.velocity = new Vector2 (speed * Mathf.Cos (angle)*Mathf.Abs(hor), speed * Mathf.Sin (angle)*Mathf.Abs(ver));
		} else {
			rb.velocity = new Vector2 (0, 0);
			ani.SetInteger ("Direcao", 2);
		}
		if (Mathf.Abs (ver) > 0) {
			ani.SetInteger ("Direcao", 3);
		}
		if (hor > 0) {
			ani.SetInteger ("Direcao", 0);
		}
		if (hor < 0) {
			ani.SetInteger ("Direcao", 1);
		}
		if (Input.GetButtonDown ("Fire1")) {
			Attack ();
		}
		if (Input.GetButtonDown ("Fire2")) {
			interact = 0.4f;
		}
		if (Input.GetButton ("Fire3")) {
			herbEffect = herbDuration;
		}

	}
	public void TakeDamage(int amount){
		HP = HP - amount;
		if (HP < 0) {
			HP = 0;
		}
	}
	public void Attack(){//apenas a animação
		ani.SetTrigger ("Atk");
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Child") {
			if (isZumbi) {
				Attack ();
				GameObject bs = Instantiate (BloodSplash);
				bs.transform.position = other.transform.position;
				Destroy (bs, bs.GetComponent<ParticleSystem> ().main.duration + bs.GetComponent<ParticleSystem> ().main.startLifetime.constantMax);
				other.gameObject.GetComponent<FadeOut> ().Run (1, new Color (1.0f, 0, 0));
				other.gameObject.GetComponent<Human> ().ads.Play ();
				Destroy (other.gameObject, 1f);
				desireForMeat = 0;
			}
		}
		if (other.tag == "Herb") {
			if (isZumbi) {
				herbs++;
				other.gameObject.GetComponent<FadeOut> ().Run (1.0f, new Color (0, 0, 1.0f));
				Destroy (other.gameObject, 1.0f);
			}
		}
		if (other.tag == "Zumbi") {
			other.gameObject.GetComponent<AudioSource> ().Play ();
		}
		if (other.tag == "Bullet") {
			other.gameObject.GetComponent<Bullet> ().AutoDestroy ();
			other.tag = "exBullet";
			TakeDamage (1);
		}
	}
	public float GetDesireForMeat(){
		return desireForMeat;
	}
	public bool GetInteract(){
		return interact > 0;
	}
	public bool TransferHerb(){
		if (herbs > 0) {
			herbs -= 1;
			return true;
		}
		return false;
	}
	public void Stop(){
		rb.velocity = new Vector2 (0, 0);
	}
	void Vidahud(){
		if (HP <= 4) {
			vidahud5.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (HP <= 3) {
			vidahud4.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (HP <= 2) {
			vidahud3.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (HP <= 1) {
			vidahud2.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (HP <= 0) {
			vidahud1.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}
