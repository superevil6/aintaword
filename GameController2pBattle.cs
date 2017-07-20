using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2pBattle : MonoBehaviour {
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

	public GameObject[] powerups;

	public GameObject gameoverPanel;

	private bool gameoverDoOnce = true;

	public float spawnInterval; //This is the initial time needed for the first powerup. Static so the powerup can access it to determine it's lifetime before expiring.
	private float spawnIncrement; //This is set to the same as spawnTime, when spawn time is met, it adds the increment value until the next powerup is spawned.
	public float despawnTime; //The powerup will despawn after this amount of time.
	private float gameTime; //Gamestats.time counts backwards, which can be confusing, so just run a seperate timer.
	// Use this for initialization
	void Start () {
		resetVariables();
		spawnIncrement = spawnInterval;
		gameoverPanel.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {

		if(!GameStats.gameOver) {
			GameStats.time -= Time.unscaledDeltaTime;
			gameTime = Time.unscaledDeltaTime;
		}
		if(GameStats.time <= 0)
		{
			GameStats.gameOver = true;
		}
		if(Time.timeSinceLevelLoad >= spawnInterval && !GameStats.gameOver)
		{
			rollPowerup();
			spawnInterval += spawnIncrement;
		}

		if(GameStats.gameOver && gameoverDoOnce)
		{
			StopAllCoroutines();
			foreach(GameObject powerup in powerups)
			{
				powerup.SetActive (false);
			}

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
		GameStats.scoreValuePOne = 10;
		GameStats.scoreValuePTwo = 10;
		GameStats.gameOver = false;
		GameStats.powerupActivated = false;
		gameoverDoOnce = true;
		GameStats.time = GameStats.gameTimeTotal;
	}

	public void rollPowerup(){
		print("rolling is running");
		int powerupIndex = Random.Range(0, powerups.Length);
		powerups[powerupIndex].SetActive(true);
		powerups[powerupIndex].GetComponentInChildren<Button>().enabled = true;
		StartCoroutine(despawn(despawnTime));
	}
	public IEnumerator despawn(float time){
		yield return new WaitForSecondsRealtime(time);
		if(!GameStats.powerupActivated)
		{
			foreach(GameObject go in powerups){
			go.SetActive(false);
		}
		}
	}
}
