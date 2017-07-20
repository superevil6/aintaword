using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler2pCoop : MonoBehaviour {
	public ThemeManager themeManager;
	public Text scorePOne;
	public Text scorePTwo;
	public Image timeLimit;
	public Text wordDisplayPOne;
	public Text wordDisplayPTwo;
	public Text gameOverScorePOne;
	public Text gameOverScorePTwo;
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
		wordDisplayPOne.text = GameStats.word;
		wordDisplayPTwo.text = GameStats.word;
		scorePOne.text = GameStats.score.ToString();
		scorePTwo.text = GameStats.score.ToString();
		timeLimit.fillAmount = (GameStats.time/GameStats.gameTimeTotal);

		if(GameStats.gameOver)
		{
			gameOverScorePOne.text = "Score: " + GameStats.score.ToString();
			gameOverScorePTwo.text = "Score: " + GameStats.score.ToString();
		}
	}
}
