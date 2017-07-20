using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswer2pCoop : MonoBehaviour {
	public CoopInstructions ci;
	public GameObject correctGraphic;
	public Sprite missoinCorrectImage;
	public Sprite justAnswerCorrectImage;
	public Sprite incorrectImage;
	Image fanfareImage;
	public AudioSource _audiosource;
	public AudioClip correctSound;
	public AudioClip incorrectSound;
	public float fanfareTime;
	// Use this for initialization
	void Start () {
		fanfareImage = correctGraphic.GetComponent<Image>();
		ci.GetComponent<CoopInstructions>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void checkAnswerOPone()
	{
		if(GameStats.getItWrong){
			print("this is running");
			WordGeneration.modified = !WordGeneration.modified;
		}
		if(!WordGeneration.modified && GameStats.playerOneShouldAnswer)
		{
			if(!GameStats.alternateAnswers){			
				GameStats.coopBonusMultiplier += 0.25f;
			}
			GameStats.score += Mathf.RoundToInt(GameStats.scoreValue * GameStats.coopBonusMultiplier);
			StartCoroutine(showCorrect(0));
		}
		else if(!WordGeneration.modified && !GameStats.playerOneShouldAnswer)
		{
			GameStats.coopBonusMultiplier = 1f;
			GameStats.score += GameStats.scoreValue;
			StartCoroutine(showCorrect(1));
		}
		else{
			GameStats.coopBonusMultiplier = 1f;
			StartCoroutine(showCorrect(2));
			//Incorrect answer.
		}
		GameStats.getItWrong = false;
		if(!GameStats.alternateAnswers){
			ci.rollInstruction();
		}
		if(!GameStats.answerAsMuchAsPossible){
			ci.rollInstruction();
		}
	}

	public void checkAnswerXPone()
	{
		if(GameStats.getItWrong){
			print("this is running");
			WordGeneration.modified = !WordGeneration.modified;
		}

		if(WordGeneration.modified && GameStats.playerOneShouldAnswer)
		{
			if(!GameStats.alternateAnswers){			
				GameStats.coopBonusMultiplier += 0.25f;
			}
			GameStats.score += Mathf.RoundToInt(GameStats.scoreValue * GameStats.coopBonusMultiplier);
			StartCoroutine(showCorrect(0));
		}
		else if(WordGeneration.modified && !GameStats.playerOneShouldAnswer)
		{
			GameStats.coopBonusMultiplier = 1f;
			GameStats.score += GameStats.scoreValue;
			StartCoroutine(showCorrect(1));
		}
		else{
			GameStats.coopBonusMultiplier = 1f;
			StartCoroutine(showCorrect(2));
			//Incorrect answer.
		}
		GameStats.getItWrong = false;
		if(!GameStats.alternateAnswers){
			ci.rollInstruction();
		}
		if(!GameStats.answerAsMuchAsPossible){
			ci.rollInstruction();
		}
		
	}

	public void checkAnswerOPTwo()
	{
		if(GameStats.getItWrong){
			print("this is running");
			WordGeneration.modified = !WordGeneration.modified;
		}

		if(!WordGeneration.modified && GameStats.playerTwoShouldAnswer)
		{
			if(!GameStats.alternateAnswers){			
				GameStats.coopBonusMultiplier += 0.25f;
			}
			GameStats.score += Mathf.RoundToInt(GameStats.scoreValue * GameStats.coopBonusMultiplier);
			StartCoroutine(showCorrect(0));
		}
		else if(!WordGeneration.modified && !GameStats.playerTwoShouldAnswer)
		{
			GameStats.coopBonusMultiplier = 1f;
			GameStats.score += GameStats.scoreValue;
			StartCoroutine(showCorrect(1));
		}
		else{
			GameStats.coopBonusMultiplier = 1f;
			StartCoroutine(showCorrect(2));
			//Incorrect answer.
		}
		GameStats.getItWrong = false;
		if(!GameStats.alternateAnswers){
			ci.rollInstruction();
		}
		if(!GameStats.answerAsMuchAsPossible){
			ci.rollInstruction();
		}
	}

	public void checkAnswerXPTwo()
	{
		if(GameStats.getItWrong){
			print("this is running");
			WordGeneration.modified = !WordGeneration.modified;
		}

		if(WordGeneration.modified && GameStats.playerTwoShouldAnswer)
		{
			if(!GameStats.alternateAnswers){			
				GameStats.coopBonusMultiplier += 0.25f;
			}
			GameStats.score += Mathf.RoundToInt(GameStats.scoreValue * GameStats.coopBonusMultiplier);
			StartCoroutine(showCorrect(0));
		}
		else if(WordGeneration.modified && !GameStats.playerTwoShouldAnswer)
		{
			GameStats.coopBonusMultiplier = 1f;
			GameStats.score += GameStats.scoreValue;
			StartCoroutine(showCorrect(1));
		}
		else{
			GameStats.coopBonusMultiplier = 1f;
			StartCoroutine(showCorrect(2));
			//Incorrect answer.
		}
		GameStats.getItWrong = false;
		if(!GameStats.alternateAnswers){
			ci.rollInstruction();
		}
		if(!GameStats.answerAsMuchAsPossible){
			ci.rollInstruction();
		}
	}

	public IEnumerator showCorrect(int correct)
	{
		switch (correct){
			case 0:
			fanfareImage.sprite = missoinCorrectImage;
			fanfareImage.color = Color.yellow;
			_audiosource.clip = correctSound;
			break;

			case 1:
			fanfareImage.sprite = justAnswerCorrectImage;
			fanfareImage.color = Color.green;
			_audiosource.clip = correctSound;
			break;

			case 2:
			fanfareImage.sprite = incorrectImage;
			fanfareImage.color = Color.red;
			_audiosource.clip = incorrectSound;
			break;
		}
		correctGraphic.SetActive(true);
		_audiosource.Play();
		yield return new WaitForSeconds(fanfareTime);
		correctGraphic.SetActive(false);

	}
}
