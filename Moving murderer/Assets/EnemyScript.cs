using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EnemyControl.enemies.Add(gameObject);
	}
	void OnDestroy(){
		EnemyControl.enemies.Remove(gameObject);
	}
	// Update is called once per frame
	
}
