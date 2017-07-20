using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyDisable : MonoBehaviour {
	public static bool penalized = false; //If this is true, it disables the buttons for a set amount of time:
	bool penaltyTimerActive = false;
	public float setPenaltyTime;
	float currentPenaltyTime;
	public Button oButton;
	public Button xButton;
	//public Text penaltyTimer; //Displays how long until the penalty stops.
	public GameObject penaltyTimer;
	public Image fillbar;
	//Image fillbar;
	// Use this for initialization
	void Start () {
		 //fillbar = penaltyTimer.GetComponentInChildren<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(penalized )
		{
			//penaltyTimerActive = true;
			StartCoroutine ("penalty");
			penalized = false;
		}
		if(penaltyTimerActive)
		{
				currentPenaltyTime -= Time.fixedUnscaledDeltaTime;
				fillbar.fillAmount = currentPenaltyTime;
		}

		//TESTING PURPOSES
		if(Input.GetKeyDown("l"))
		{
			penalized = true;
		}
	}

	public IEnumerator penalty()
	{
		oButton.interactable = false;
		xButton.interactable = false;
		currentPenaltyTime = setPenaltyTime;
		penaltyTimerActive = true;
		yield return new WaitForSecondsRealtime (setPenaltyTime);
		penaltyTimerActive = false;
		oButton.interactable = true;
		xButton.interactable = true;
	}
}
