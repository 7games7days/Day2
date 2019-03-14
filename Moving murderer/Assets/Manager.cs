using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	// Use this for initialization
 	public void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	public void NextLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		Time.timeScale = 1;
	}
}
