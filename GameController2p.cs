using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2p : MonoBehaviour {
	public Button pOneO;
	public Button pOneX;
	public Button pTwoO;
	public Button pTwoX;
	public Image pOneVictoryIcon;
	public Image pTwoVictoryIcon;
	public Text pOneVictoryText;
	public Text pTwoVictoryText;

	public Sprite victory;
	public Sprite defeat;
	public Sprite draw;

	public GameObject gameoverPanel;

	private bool gameoverDoOnce;
	// Use this for initialization
	void Start () {
		resetVariables ();
		gameoverPanel.SetActive (false);
		gameoverDoOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameStats.gameOver) {
			GameStats.time -= Time.unscaledDeltaTime;
		}
		if(GameStats.time <= 0)
		{
			GameStats.gameOver = true;
		}
		if(GameStats.gameOver && gameoverDoOnce)
		{
			if(GameStats.scorePlayerOne > GameStats.scorePlayerTwo)
			{
				GameStats.pOneVictories += 1;
				pOneVictoryIcon.sprite = victory;
				pTwoVictoryIcon.sprite = defeat;
				pOneVictoryText.color = Color.yellow;
				pOneVictoryText.text = "Victory!";
				pTwoVictoryText.color = Color.blue;
				pTwoVictoryText.text = "Defeat...";
			}
			else if(GameStats.scorePlayerOne < GameStats.scorePlayerTwo)
			{
				GameStats.pTwoVictories += 1;
				pOneVictoryIcon.sprite = defeat;
				pTwoVictoryIcon.sprite = victory;
				pTwoVictoryText.color = Color.yellow;
				pTwoVictoryText.text = "Victory!";
				pOneVictoryText.color = Color.blue;
				pOneVictoryText.text = "Defeat...";
			}
			else{ //tie game.
				GameStats.draws += 1;
				pOneVictoryIcon.sprite = draw;
				pTwoVictoryIcon.sprite = draw;
				pOneVictoryText.color = Color.gray;
				pOneVictoryText.text = "Draw!";
				pTwoVictoryText.color = Color.gray;
				pTwoVictoryText.text = "Draw!";
			}
			gameoverPanel.SetActive (true);

			pOneO.enabled = false;
			pOneX.enabled = false;
			pTwoO.enabled = false;
			pTwoX.enabled = false;
			gameoverDoOnce = false;
		}
	}

	public void newGame()
	{
		SceneManager.LoadScene (0);
	}

	public void resetVariables()
	{
		GameStats.scorePlayerOne = 0;
		GameStats.scorePlayerTwo = 0;
		GameStats.gameOver = false;
		GameStats.time = GameStats.gameTimeTotal;
	}


}
