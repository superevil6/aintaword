using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
	// Consider different highscores per list/difficulty.
	public static int score;
	public static float challengeMultiplier = 1f;
	public static int wordsAnsweredCorrectly;
	public static int highScore;
	public static int highScoreEasy;
	public static int highScoreNormal;
	public static int highScoreHard;
	public static int scoreValue = 10;
	public static int scoreValuePOne = 10;
	public static int scoreValuePTwo = 10;
	public static int streak = 0;
	public static int streakNeededForChallenge = 5;


	//Multiplayer stats
	public static int scorePlayerOne;
	public static int scorePlayerTwo;
	public static int pOneVictories;
	public static int pTwoVictories;
	public static int draws;
	public static float coopBonusMultiplier = 1f;
	public static bool playerOneShouldAnswer; 
	public static bool playerTwoShouldAnswer;
	public static bool getItWrong; 

	public static bool alternateAnswers;
	public static bool answerAsMuchAsPossible;

	//Adventure Mode
	public static int levelIndex;

	//Multiplyaer Coop and Battle
	public static float time;
	public static float gameTimeTotal = 15f;
	public static bool gameOver = false;
	public static bool multiplayerPause;

	public static bool spawnPowerup;
	public static bool powerupActivated;

	public static string word; //This is the word to be displayed in all game modes.
	public static string correctWord; //When the player misses a modified word, it'll add the modified word, and the correct word to a list that they can view at the end of the game.
	public static List<string> missedWords = new List<string>();
	public static List<string> correctWords = new List<string> (); //When a word is missed, it's added to missed list, and the correct version is added to this list at the same index so both can be displayed at the end of the game.

	public static Theme selectedTheme;

	public static RPGUIManager rpgUI;
	public static List<int> enemyIds = new List<int>();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
