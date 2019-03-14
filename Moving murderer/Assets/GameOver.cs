using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	public GameObject gameOverPanel;
	public GameObject winPanel;
	void Start () {
		
	}
	
	// Update is called once per frame
	public void GameOverLose () {
		gameOverPanel.SetActive(true);
		Time.timeScale = 0;
	}
	public void GameOverWin(){
		winPanel.SetActive(true);
		Time.timeScale = 0;
	}
}
