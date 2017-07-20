using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelect : MonoBehaviour {
	public int players; //True implies singleplayer, False implies multiplayer
	public Slider timeSlider;
	public Text timeLimitIndicator;

	// Use this for initialization
	void Start () {
		WordGeneration.easy = false;
		WordGeneration.normal = false;
		WordGeneration.hard = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeSlider.value < 0.25f)
		{
			GameStats.gameTimeTotal = 15f;
			timeLimitIndicator.text = "15 seconds";
		}
		if(timeSlider.value >= 0.25f && timeSlider.value < 0.5f)
		{
			GameStats.gameTimeTotal = 30f;
			timeLimitIndicator.text = "30 seconds";
		}
		if(timeSlider.value > 0.5f && timeSlider.value < 0.75f)
		{
			GameStats.gameTimeTotal = 45f;
			timeLimitIndicator.text = "45 seconds";
		}
		if(timeSlider.value > 0.75f)
		{
			GameStats.gameTimeTotal = 60f;
			timeLimitIndicator.text = "60 seconds";
		}
	}

	public void easyMode()
	{
		WordGeneration.easy = true;
	}
	public void normalMode()
	{
		WordGeneration.normal = true;
	}
	public void hardMode()
	{
		WordGeneration.hard = true;
	}
		

	public void selectMode(int players)
	{
		/* If other modes such as battle/coop use seperate scenes, modify this later to use an INT instead of a bool. */
		SceneManager.LoadScene (players);
	}
	public void selectAdventureLevel(int level)
	{
		GameStats.levelIndex = level;
		SceneManager.LoadScene(5);
	}

}
