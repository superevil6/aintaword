using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {
	public GameObject correctGraphic;
	public Sprite correctImage;
	public Sprite incorrectImage;
	Image fanfareImage;
	public AudioSource _audioSource;
	public AudioClip correctSound;
	public AudioClip incorrectSound;
	public Text streakIndicator;
	public float fanfareTime;
	// Use this for initialization
	void Start () {
		fanfareImage = correctGraphic.GetComponent<Image> ();
		streakIndicator.text = ""; //There is no streak when you start, so make sure the text isn't visible.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkAnswerO()
	{
		StopAllCoroutines ();
		if(WordGeneration.modified == false) //Correct answer
		{
			GameStats.score += Mathf.RoundToInt (GameStats.scoreValue + GameStats.streak * GameStats.challengeMultiplier);
			GameStats.streak += 1;
			GameStats.wordsAnsweredCorrectly += 1;
			StartCoroutine ("showCorrect");
			if(GameStats.streak > 1){
				StartCoroutine ("showStreak");
			}
		}
		else //Incorrect answer
		{
			
			PenaltyDisable.penalized = true;
			GameStats.streak = 0;
			GameStats.streakNeededForChallenge = 5;
			if(WordGeneration.modified)
			{
				GameStats.missedWords.Add (GameStats.word);
				GameStats.correctWords.Add (GameStats.correctWord);
			}			
			StartCoroutine ("showIncorrect");
			StopCoroutine ("showStreak");
		}
	}

	public void checkAnswerX()
	{
		if(WordGeneration.modified == true) //Correct answer
		{
			GameStats.score += Mathf.RoundToInt (GameStats.scoreValue + GameStats.streak * GameStats.challengeMultiplier);
			GameStats.streak += 1;
			GameStats.wordsAnsweredCorrectly += 1;
			StartCoroutine ("showCorrect");
			if(GameStats.streak > 1){
				StartCoroutine ("showStreak");
			}
		}
		else //Incorrect answer
		{
			PenaltyDisable.penalized = true;
			GameStats.streak = 0;
			GameStats.streakNeededForChallenge = 5;
			if(WordGeneration.modified)
			{
				GameStats.missedWords.Add (GameStats.word);
				GameStats.correctWords.Add (GameStats.correctWord);
			}
			StartCoroutine ("showIncorrect");
			StopCoroutine ("showStreak");

		}
	}

	public IEnumerator showCorrect()
	{
		fanfareImage.sprite = correctImage;
		fanfareImage.color = Color.green;
		correctGraphic.SetActive (true);
		_audioSource.clip = correctSound;
		_audioSource.Play ();
		yield return new WaitForSeconds(fanfareTime);
		correctGraphic.SetActive (false);
	}

	public IEnumerator showIncorrect()
	{
		fanfareImage.sprite = incorrectImage;
		fanfareImage.color = Color.red;
		correctGraphic.SetActive (true);
		_audioSource.clip = incorrectSound;
		_audioSource.Play ();
		yield return new WaitForSeconds(fanfareTime);
		correctGraphic.SetActive (false);
	}

	public IEnumerator showStreak()
	{
		float newXPosition = Random.Range(streakIndicator.transform.localPosition.x - 5, streakIndicator.transform.localPosition.x + 5);
		float newYPosition = Random.Range (streakIndicator.transform.localPosition.y - 2, streakIndicator.transform.localPosition.y + 2);
		streakIndicator.transform.localPosition = new Vector2 (newXPosition, newYPosition);
		streakIndicator.fontSize = 12 + GameStats.streak;
		streakIndicator.text = "streak x " + GameStats.streak;
		yield return new WaitForSecondsRealtime (1f);
		streakIndicator.text = "";
	}
}
