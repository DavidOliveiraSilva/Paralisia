using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbGenerator : MonoBehaviour {
	public GameObject herb;
	public float interval;
	private float lastH = 0;
	private BoxCollider2D bc;
	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = bc.bounds.center.x - bc.bounds.extents.x;
		float y = bc.bounds.center.y - bc.bounds.extents.y;
		float x2 = bc.bounds.center.x + bc.bounds.extents.x;
		float y2 = bc.bounds.center.y + bc.bounds.extents.y;
		if (Time.time - lastH > interval) {
			GameObject h = Instantiate (herb);
			h.transform.position = new Vector3 (Random.Range (x, x2), Random.Range (y, y2), h.transform.position.z);
			lastH = Time.time;
		}
	}
}
