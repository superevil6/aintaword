using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoopInstructions : MonoBehaviour {
public Text playerOneInstruction;
public Text playerTwoInstruction; 
public float answerTime; //This is for answer as much as possible and alternate.
private bool playerOneMission; //true is player One, false is player two.
private bool playerOneRecievesInstruction;

	// Use this for initialization
	void Start () {
		rollInstruction();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rollInstruction()
	{
		if(!GameStats.alternateAnswers)
		{
			if(!GameStats.answerAsMuchAsPossible)
			{
				int whichPlayerMission = Random.Range(0, 2);
				if(whichPlayerMission == 0){
					playerOneMission = true;
				}
				else{
					playerOneMission = false;
				}
			int whichPlayerRecievesInstruction = Random.Range(0, 2);
				if(whichPlayerRecievesInstruction == 0){
					playerOneRecievesInstruction = true;
				}
				else{
					playerOneRecievesInstruction = false;
				}
			int instructionIndex = Random.Range(0, 5);
		switch (instructionIndex){
			case 0:
			onlyAnswer(playerOneMission, playerOneRecievesInstruction);
			break;

			case 1:
			dontAnswer(playerOneMission, playerOneRecievesInstruction);
			break;

			case 2:
			getItWrong(playerOneMission, playerOneRecievesInstruction);
			break;

			case 3:
			alternate(playerOneMission, playerOneRecievesInstruction, answerTime);
			break;
			case 4:
			StartCoroutine(answerAsMuchAsPossible(playerOneRecievesInstruction, answerTime));
			break;
		}
			}
		}
		
	}

	public void onlyAnswer(bool pOneInstruction, bool pOneMission)
	{
		if(pOneInstruction && pOneMission){
			playerOneInstruction.text = "Answer! Player one only!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else if(pOneInstruction && !pOneMission){
			playerOneInstruction.text = "Answer! Player two only!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
		else if(!pOneInstruction && pOneMission){
			playerTwoInstruction.text = "Answer! Player one only!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else{
			playerTwoInstruction.text = "Answer! Player two only!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
	}

	public void dontAnswer(bool pOneInstruction, bool pOneMission)
	{
		if(pOneInstruction && pOneMission){
			playerOneInstruction.text = "Player one don't answer!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
		else if(pOneInstruction && !pOneMission){
			playerOneInstruction.text = "Player two don't answer!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else if(!pOneInstruction && pOneMission){
			playerTwoInstruction.text = "Player one don't answer!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
		else{
			playerTwoInstruction.text = "Player two don't answer!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;

		}
	}
	
	public void getItWrong(bool pOneInstruction, bool pOneMission)
	{
		GameStats.getItWrong = true;
		if(pOneInstruction && pOneMission){
			playerOneInstruction.text = "Get it wrong player one!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else if(pOneInstruction && !pOneMission){
			playerOneInstruction.text = "Get it wrong player two!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
		else if(!pOneInstruction && pOneMission){
			playerTwoInstruction.text = "Get it wrong player one!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else{
			playerTwoInstruction.text = "Get it wrong player two!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
	}
	
	public IEnumerator alternate(bool pOneInstruction, bool pOneMission, float answerTime)
	{
		GameStats.alternateAnswers = true;
		if(pOneInstruction && pOneMission){
			playerOneInstruction.text = "Alternate answering, start with player one!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else if(pOneInstruction && !pOneMission){
			playerOneInstruction.text = "Alternate answering, start with player two!";
			playerTwoInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
		else if(!pOneInstruction && pOneMission){
			playerTwoInstruction.text = "Alternate answering, start with player one!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = true;
			GameStats.playerTwoShouldAnswer = false;
		}
		else{
			playerTwoInstruction.text = "Alternate answering, start with player two!";
			playerOneInstruction.text = "";
			GameStats.playerOneShouldAnswer = false;
			GameStats.playerTwoShouldAnswer = true;
		}
		yield return new WaitForSecondsRealtime(answerTime);
		GameStats.alternateAnswers = false;
		rollInstruction();
	}

	public IEnumerator answerAsMuchAsPossible(bool pOneInstruction, float answerTime)
	{
		GameStats.answerAsMuchAsPossible = true;
		if(pOneInstruction){
			playerOneInstruction.text = "Go go go! Both players answer!";
			playerTwoInstruction.text = "";
		}
		else{
			playerTwoInstruction.text = "Go go go! Both players answer!";
			playerOneInstruction.text = "";
		}
		yield return new WaitForSecondsRealtime(answerTime);
		GameStats.answerAsMuchAsPossible = false;
		rollInstruction();
	}
}
