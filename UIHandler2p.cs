using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler2p : MonoBehaviour {
	public ThemeManager themeManager;
	public Text scorePOne;
	public Text scorePTwo;
	public Image timeLimit;
	public Text wordDisplayPOne;
	public Text wordDisplayPTwo;
	public Text gameoverScorePOne;
	public Text gameoverScorePTwo;
	// Use this for initialization
	void Awake()
	{
		GameStats.selectedTheme = themeManager.themes[0];
		themeManager.setTheme(GameStats.selectedTheme);
	}
	void Start () {
		GameStats.time = GameStats.gameTimeTotal;
	}
	
	// Update is called once per frame
	void Update () {
		scorePOne.text = GameStats.scorePlayerOne.ToString ();
		scorePTwo.text = GameStats.scorePlayerTwo.ToString ();
		wordDisplayPOne.text = GameStats.word;
		wordDisplayPTwo.text = GameStats.word;
		timeLimit.fillAmount = (GameStats.time / GameStats.gameTimeTotal);

		if(GameStats.gameOver)
		{
			gameoverScorePOne.text = "Player one score: " + GameStats.scorePlayerOne.ToString () + "\nPlayer two score: " + GameStats.scorePlayerTwo.ToString() + "\nWins: " + GameStats.pOneVictories.ToString () + "\nLoses: " + GameStats.pTwoVictories.ToString () + "\nDraws: " + GameStats.draws.ToString ();
			gameoverScorePTwo.text = "Player one score: " + GameStats.scorePlayerOne.ToString () + "\nPlayer two score: " + GameStats.scorePlayerTwo.ToString() + "\nWins: " + GameStats.pTwoVictories.ToString () + "\nLoses: " + GameStats.pOneVictories.ToString () + "\nDraws: " + GameStats.draws.ToString ();
		}
	}
}
