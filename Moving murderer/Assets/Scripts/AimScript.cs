using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {

	public Camera cam;
	// Use this for initialization
	void Start () {
		cam = Camera.main;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = (Vector2) cam.ScreenToWorldPoint(Input.mousePosition);
	}
}
