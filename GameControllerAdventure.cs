using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerAdventure : MonoBehaviour {

public Button O;
public Button X;
public AudioSource bgm;
public AdventureMode am;
public WordGeneration wg;
public WordManipulation wm;
public ThemeManager tm;
private bool conditionPoints;
private bool conditionWords;
private int words;
private int points;
private string handicapOne;
private string handicapTwo;
private float timeLimit;
public GameObject gameoverPanel;
public GameObject levelIntroPanel;
public Text levelIntroPanelFlavorText;
public Text levelIntroPanelWorldName;
public Text levelIntroPanelTimeLimit;
public Text levelIntroPanelRequirement;
public GameObject countDownPanel;
public Text countDownPanelText;
public Text gameoverText;
public Text gameoverVictoryRequirement;
public Text gameoverScore;
public Text missedWordsList;
public Button replayLevel;
public Button toMenu;
public Button toNextLevel;
private bool gameStarted;
private bool doOnce;
private bool victory;
	// Use this for initialization
	void Awake()
	{
		setStage();
		wg.setWordList(am.levels[GameStats.levelIndex].WordListName);
	}
	void Start () {
		doOnce = true;
		resetVariables();
		countDownPanel.SetActive(false);
		levelIntroPanel.SetActive(true);
		gameoverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!GameStats.gameOver && gameStarted){
			GameStats.time -= Time.unscaledDeltaTime;
			if(handicapOne == "moving" || handicapTwo == "moving"){
				wm.moveText(wm.wordBoxToManipulate);
			}
			if(handicapOne == "spinning" || handicapTwo == "spinning"){
				wm.spinText(wm.wordBoxToManipulate);
			}
			if(handicapOne == "reverse" || handicapTwo == "reverse"){
				wm.reverseText(wm.wordToManipulate);
			}
			if(handicapOne == "size" || handicapTwo == "size"){
				wm.sizeChange(wm.wordToManipulate);
			}
			if(handicapOne == "color" || handicapTwo == "color"){
				wm.colorChange(wm.wordToManipulate);
			}
			if(handicapOne == "blinking" || handicapTwo == "blinking"){
				wm.blinkText(wm.wordToManipulate);
			}
		}
		if(conditionPoints && GameStats.score >= points)
		{
			victory = true;
		}
		if(GameStats.time <= 0)
		{
			GameStats.gameOver = true;
		}
		if(GameStats.gameOver){
			gameoverPanel.SetActive(true);
			if(doOnce){
				missedWordsList.text += "Incorrect Guess:" + "\t\t" + "Correct Word:\n";
				for (int i = 0; i <= GameStats.missedWords.Count - 1; i++) {
					missedWordsList.text += GameStats.missedWords [i] + "\t\t" + GameStats.correctWords [i] + "\n";
				}
				doOnce = false;
			}
			if(conditionPoints){
				gameoverVictoryRequirement.text = "Score needed: " + points.ToString();
				gameoverScore.text = "Score: " + GameStats.score.ToString();
			}
			else if(conditionWords){
				gameoverVictoryRequirement.text = "Words needed " + words.ToString();
				gameoverScore.text = "Words: " + GameStats.wordsAnsweredCorrectly.ToString();
			}
			if(victory){
				gameoverText.text = "Congratulations.";
				toNextLevel.enabled = true;
			}
			else{
				gameoverText.text = "Try again!";
				toNextLevel.enabled = false;
			}
			O.interactable = false;
			X.interactable = false;
		}
	}

	public void setStage()
	{
		wg.setWordList(am.levels[GameStats.levelIndex].WordListName);
		foreach(string _word in am.levels[GameStats.levelIndex].WordsToAdd){
			wg.wordList.Add(_word);
		}
		bgm.clip = am.levels[GameStats.levelIndex].BGM;
		tm.setTheme(tm.themes[am.levels[GameStats.levelIndex].ThemeIndex]); //Whoa, that's confusing.
		conditionPoints = am.levels[GameStats.levelIndex].ConditionPoints;
		conditionWords = am.levels[GameStats.levelIndex].ConditionWords;
		GameStats.gameTimeTotal = am.levels[GameStats.levelIndex].TimeLimit;
		words = am.levels[GameStats.levelIndex].Words;
		points = am.levels[GameStats.levelIndex].Points;
		handicapOne = am.levels[GameStats.levelIndex].HandicapOne;
		handicapTwo = am.levels[GameStats.levelIndex].HandicapTwo;
		levelIntroPanelWorldName.text = am.levels[GameStats.levelIndex].WorldName;
		levelIntroPanelFlavorText.text = am.levels[GameStats.levelIndex].LevelIntroFlavorText;
		levelIntroPanelTimeLimit.text = "Time limit: " + am.levels[GameStats.levelIndex].TimeLimit.ToString() + " seconds";
		if(conditionPoints){
			levelIntroPanelRequirement.text = "Points needed: " + am.levels[GameStats.levelIndex].Points.ToString() + " points";
		}
		else{
			levelIntroPanelRequirement.text = "Words needed: " + am.levels[GameStats.levelIndex].Words.ToString() + " words";
		}
	}

	
	public void resetVariables()
	{
		gameStarted = false;
		GameStats.score = 0;
		GameStats.streak = 0;
		GameStats.wordsAnsweredCorrectly = 0;
		GameStats.streakNeededForChallenge = 5;
		GameStats.missedWords.Clear ();
		GameStats.correctWords.Clear ();
		GameStats.gameOver = false;
		GameStats.time = GameStats.gameTimeTotal;
	}

	public void startGame(int countdownTime){
		StartCoroutine(startGameCoroutine(countdownTime));
	}
	public IEnumerator startGameCoroutine(int countdownTime)
	{
		levelIntroPanel.SetActive(false);
		countDownPanel.SetActive(true);
		for(int i = countdownTime; i > 0; i--){
			countDownPanelText.text = i.ToString();
			yield return new WaitForSecondsRealtime(1);
		}
		countDownPanel.SetActive(false);
		gameStarted = true;
	}
}
