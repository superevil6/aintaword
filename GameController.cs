using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	

	public Button O;
	public Button X;
	public Text missedWordsList;
	//public Button OPTwo;
	//public Button XPTwo;

	public GameObject gameoverPanel;

	public GameObject challengeManager; //This will appear after a certain streak to offer the player a challenge modifier which manipulates the text increasing the challenge and score payout.
	
	private bool doOnce; //For generating the list of incorrect words.
	// Use this for initialization
	void Awake(){
		resetVariables ();
	}
	void Start () {
		//resetVariables();
		doOnce = true;
		gameoverPanel.SetActive (false);
		challengeManager.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameStats.streak >= GameStats.streakNeededForChallenge){
			challengeManager.SetActive(true);
			GameStats.streakNeededForChallenge += 5;
		}
		if(!GameStats.gameOver) {
			GameStats.time -= Time.unscaledDeltaTime;

		}
		if(GameStats.time <= 0)
		{
			GameStats.gameOver = true;
		}
		if(GameStats.gameOver)
		{
			gameoverPanel.SetActive (true);
			if(doOnce){
				missedWordsList.text += "Incorrect Guess:" + "\t\t" + "Correct Word:\n";
				for (int i = 0; i <= GameStats.missedWords.Count - 1; i++) {
					missedWordsList.text += GameStats.missedWords [i] + "\t\t" + GameStats.correctWords [i] + "\n";
				}
				doOnce = false;
			}
			if(GameStats.score > GameStats.highScoreEasy && WordGeneration.easy)
			{
				GameStats.highScoreEasy = GameStats.score;
			}
			else if(GameStats.score > GameStats.highScoreNormal && WordGeneration.normal)
			{
				GameStats.highScoreNormal = GameStats.score;
			}
			else if (GameStats.score > GameStats.highScoreHard && WordGeneration.hard)
			{
				GameStats.highScoreHard = GameStats.score;
			}
			O.enabled = false;
			X.enabled = false;

		}
	}

	public void newGame()
	{
		SceneManager.LoadScene (0);
	}

	public void resetVariables()
	{
		GameStats.score = 0;
		GameStats.streak = 0;
		GameStats.challengeMultiplier = 1f;
		GameStats.streakNeededForChallenge = 5;
		GameStats.missedWords.Clear ();
		GameStats.correctWords.Clear ();
		GameStats.gameOver = false;
		GameStats.time = GameStats.gameTimeTotal;
	}
}
