using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {
	public Text score;
	public Text highscore;
	public Text wordToDisplay;
	//public Text timeLimit;
	public Text gameoverScore;
	public Text gameoverHighscore;
	public Image timeLimit;
	public ThemeManager themeManager;
	// Use this for initialization
	void Awake()
	{
		GameStats.selectedTheme = themeManager.themes[0];
		//themeManager.setTheme(GameStats.selectedTheme);
	}
	void Start () {
		GameStats.time = GameStats.gameTimeTotal;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + GameStats.score.ToString();
		wordToDisplay.text = GameStats.word;
		timeLimit.fillAmount = (GameStats.time / GameStats.gameTimeTotal);
		if(WordGeneration.easy)
		{
			highscore.text = "Easy mode highscore: " + GameStats.highScoreEasy.ToString ();
		}
		else if(WordGeneration.normal)
		{
			highscore.text = "Normal mode highscore: " + GameStats.highScoreNormal.ToString ();
		}
		else if(WordGeneration.hard)
		{
			highscore.text = "Hard mode highscore: " + GameStats.highScoreHard.ToString ();
		}
		if(GameStats.gameOver)
		{
			gameoverScore.text = "Score: \n" + GameStats.score.ToString ();
			if(WordGeneration.easy)
			{
				gameoverHighscore.text = "Easy mode highscore: \n" + GameStats.highScoreEasy.ToString ();
			}
			else if(WordGeneration.normal)
			{
				gameoverHighscore.text = "Normal mode highscore: \n" + GameStats.highScoreNormal.ToString ();
			}
			else if(WordGeneration.hard)
			{
				gameoverHighscore.text = "Hard mode highscore: \n" + GameStats.highScoreHard.ToString ();
			}
		}
	}
}
