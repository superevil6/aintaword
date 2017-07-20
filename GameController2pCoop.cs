using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController2pCoop : MonoBehaviour {
	public LoadScene ls;
	public CoopInstructions ci;
	public GameObject gameoverPanel;
	public Button[] playerButtons;
	private bool gameoverDoOnce;
	// Use this for initialization
	void Start () {
		ls.GetComponent<LoadScene>();
		resetVariables ();
		gameoverPanel.SetActive(false);
		gameoverDoOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameStats.gameOver){
			GameStats.time -= Time.unscaledDeltaTime;
		}
		if(GameStats.time <= 0){
			GameStats.gameOver = true;
		}
		if(GameStats.gameOver && gameoverDoOnce){
			gameoverPanel.SetActive(true);

			foreach(Button butts in playerButtons){
				butts.enabled = false;
			}
			gameoverDoOnce = false;
		}
	}

	public void newGame()
	{
		ls.loadscene(4);
	}
	public void resetVariables()
	{
		GameStats.score = 0;
		GameStats.coopBonusMultiplier = 1f;
		GameStats.gameOver = false;
		GameStats.time = GameStats.gameTimeTotal;

	}
}
