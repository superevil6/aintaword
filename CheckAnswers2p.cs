using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswers2p : MonoBehaviour {
	public GameObject correctGraphic;
	public Sprite correctImage;
	public Sprite incorrectImage;
	Image fanfareImage;
	public AudioSource _audioSource;
	public AudioClip correctSound;
	public AudioClip incorrectSound;
	public float fanfareTime;
	// Use this for initialization
	void Start () {
		fanfareImage = correctGraphic.GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkAnswerOPOne()
	{
		if(!GameStats.multiplayerPause)
		{
			StopAllCoroutines ();
			if (!WordGeneration.modified) { //A correct answer.
				GameStats.scorePlayerOne += GameStats.scoreValuePOne; //Consider streaks latter, the inclusion of streaks might make the match one sided though.
				if(BattleModePowers.pOneSharePTwo){
					GameStats.scorePlayerTwo += GameStats.scoreValuePOne / 2;
				}
				//Place for streak if needed.
				StartCoroutine (showCorrect (true, true));
			} else {
				GameStats.scorePlayerTwo += GameStats.scoreValuePTwo;
				StartCoroutine (showCorrect (false, true));
			}}
	}
	public void checkAnswerXPOne()
	{
		if(!GameStats.multiplayerPause)
		{
			StopAllCoroutines ();
			if (WordGeneration.modified) { //A correct answer.
				GameStats.scorePlayerOne += GameStats.scoreValuePOne; //Consider streaks latter, the inclusion of streaks might make the match one sided though.
				if(BattleModePowers.pOneSharePTwo){
					GameStats.scorePlayerTwo += GameStats.scoreValuePOne / 2;
				}
				//Place for streak if needed.
				StartCoroutine (showCorrect (true, true));
			} else {
				GameStats.scorePlayerTwo += GameStats.scoreValuePTwo;
				StartCoroutine (showCorrect (false, true));
			}
		}
	}

	public void checkAnswerOPTwo()
	{
		if(!GameStats.multiplayerPause)
		{
			StopAllCoroutines ();
			if (!WordGeneration.modified) { //A correct answer.
				GameStats.scorePlayerTwo += GameStats.scoreValuePTwo; //Consider streaks latter, the inclusion of streaks might make the match one sided though.
				if(BattleModePowers.pTwoSharePOne){
					GameStats.scorePlayerOne += GameStats.scoreValuePTwo / 2;
				}
				//Place for streak if needed.
				StartCoroutine (showCorrect (true, false));
			} else {
				GameStats.scorePlayerOne += GameStats.scoreValuePOne;
				StartCoroutine (showCorrect (false, false));
			}}
	}
	public void checkAnswerXPTwo()
	{
		if(!GameStats.multiplayerPause)
		{
			StopAllCoroutines ();
			if (WordGeneration.modified) { //A correct answer.
				GameStats.scorePlayerTwo += GameStats.scoreValuePTwo; //Consider streaks latter, the inclusion of streaks might make the match one sided though.
				//Place for streak if needed.
				if(BattleModePowers.pTwoSharePOne){
					GameStats.scorePlayerOne += GameStats.scoreValuePTwo / 2;
				}
				StartCoroutine (showCorrect (true, false));
			} else {
				GameStats.scorePlayerOne += GameStats.scoreValuePOne;
				StartCoroutine (showCorrect (false, false));
			}}
	}
	public IEnumerator showCorrect(bool correct, bool player)
	{
		if(player) //true is for player 1, false is for player 2.
		{
			correctGraphic.transform.localPosition = new Vector2 (0, -300); //this is a temporary position, figure out the correct position later.
		}
		else {
			correctGraphic.transform.localPosition = new Vector2 (0, 300);
		}
		if(correct){
			fanfareImage.sprite = correctImage;
			fanfareImage.color = Color.green;
			_audioSource.clip = correctSound;
		}
		else{
			fanfareImage.sprite = incorrectImage;
			fanfareImage.color = Color.red;
			_audioSource.clip = incorrectSound;
		}

		correctGraphic.SetActive (true);
		_audioSource.Play ();
		yield return new WaitForSeconds (fanfareTime);
		correctGraphic.SetActive (false);
	}
}
