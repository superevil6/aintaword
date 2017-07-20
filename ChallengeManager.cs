using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour {
public Button challengeButton;
public Image challengeDisplay;
public AudioSource se;
public AudioClip[] sePool;
public Sprite[] challengeSprites;
public WordManipulation wm;
public Text wordToManipulate;
public GameObject wordBoxToManipulate;
public string[] manipulations;
public List<string> activeManipulations;
	// Use this for initialization
	void Start () {
		activeManipulations.Clear();
	}
	
	// Update is called once per frame
	void Update () {
		if(activeManipulations.Contains("moving")){
			wm.moveText(wordBoxToManipulate);
		}
		if(activeManipulations.Contains("spinning")){
			wm.spinText(wordBoxToManipulate);
		}
		if(activeManipulations.Contains("size")){
			wm.sizeChange(wordToManipulate);
		}
		if(activeManipulations.Contains("color")){
			wm.colorChange(wordToManipulate);
		}
		if(activeManipulations.Contains("reverse")){
			wm.reverseText(wordToManipulate);
		}
		if(activeManipulations.Contains("blinking")){
			wm.blinkText(wordToManipulate);
		}
	}

	public void initiateChallenge(){
		StartCoroutine("slotChallenge");
	}
	public void rollChallenge()
	{
		int manipulationIndex = Random.Range(0, manipulations.Length);
		challengeDisplay.sprite = challengeSprites[manipulationIndex]; //This might not be a good idea.
		activeManipulations.Add(manipulations[manipulationIndex]);
		foreach(string activeManips in activeManipulations){
			GameStats.challengeMultiplier += 0.25f;
		}
	}
	public IEnumerator slotChallenge()
	{
		se.clip = sePool[0];
		int fastSpins = Random.Range(10, 25); //25 is an arbitrary number, change if it's too long or too quick.
		for(int i = 0; i < fastSpins; i++){
			challengeDisplay.sprite = challengeSprites[Random.Range(0, challengeSprites.Length)];
			se.Play();
			yield return new WaitForSeconds(0.15f);
		}
		int slowSpins = Random.Range(5, 10);
		for(int i = slowSpins; i > 0; i--){
			challengeDisplay.sprite = challengeSprites[Random.Range(0, challengeSprites.Length)];
			se.Play();
			yield return new WaitForSeconds(slowSpins/10);
		}
		rollChallenge();
	}
}
