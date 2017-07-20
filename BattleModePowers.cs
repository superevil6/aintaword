using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleModePowers : MonoBehaviour {
	public static bool pOneSharePTwo; //When this ie enabled, player one shares half their points with player two.
	public static bool pTwoSharePOne; //Opposite ^
	public Button playerOneO;
	public Button playerOneX;
	public Button playerTwoO;
	public Button playerTwoX;
	public float powerupDuration;
	public float timeStopDuration;

	private Vector3 originalOPosition;
	private Vector3 originalXPosition;
	public WordManipulation wm;
	private bool doOnce = true;

	public Text playerOneText;
	public Text playerTwoText;
	public GameObject playerOneTextBox;
	public GameObject playerTwoTextBox;

	private bool roatationPOne;
	private bool rotationPTwo;
	private bool reverseTextPOne;
	private bool reverseTextPTwo;
	private bool colorChangePOne;
	private bool colorChangePTwo;
	private bool sizeChangePOne;
	private bool sizeChangePTwo;
	private bool movePOne;
	private bool movePTwo;
	private bool blinkPOne;
	private bool blinkPTwo;
	// Use this for initialization
	void Start () {
		wm.GetComponent<WordManipulation>();
	}
	
	// Update is called once per frame
	void Update () {
		if(roatationPOne){
			wm.spinText(playerOneTextBox);
		}
		if(rotationPTwo){
			wm.spinText(playerTwoTextBox);
		}
		if(colorChangePOne){
			wm.colorChange(playerOneText);
		}
		if(colorChangePTwo){
			wm.colorChange(playerTwoText);
		}
		if(sizeChangePOne){
			wm.sizeChange(playerOneText);
		}
		if(sizeChangePTwo){
			wm.sizeChange(playerTwoText);
		}
		if(reverseTextPOne){
			wm.reverseText(playerOneText);
		}
		if(reverseTextPTwo){
			wm.reverseText(playerTwoText);
		}
		if(movePOne){
			wm.moveText(playerOneTextBox);
		}
		if(movePTwo){
			wm.moveText(playerTwoTextBox);
		}
		if(blinkPOne){
			wm.blinkText(playerOneText);
		}
		if(blinkPTwo){
			wm.blinkText(playerTwoText);
		}

	}

	public void enableTimesTwoScore(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(timesTwoScore(player));
	}
	public void enableDisableButtons(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(disableButtons(player));
	}
	public void enableSwapButtons(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(swapButtons(player));
	}
	public void enableSharePoints(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(sharePoints(player));
	}
	public void enableRotatingText(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(textRotation(player));
	}
	public void enableColorText(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(textColorChange(player));
	}
	public void enableTextSize(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(textSizeChange(player));
	}
	public void enableTextReverse(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(reverseText(player));
	}
	public void enableTextMove(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(moveText(player));
	}
	public void enableBlinkText(int player){
		GameStats.powerupActivated = true;
		StartCoroutine(blinkText(player));
	}


	public IEnumerator timesTwoScore(int player) //Insert player that recieves the powerdown.
	{
		if(player == 0){ //Player one
			GameStats.scoreValuePOne *= 2;
		}
		else{ //player two
			GameStats.scoreValuePTwo *= 2;
		}

		yield return new WaitForSecondsRealtime (powerupDuration);

		if(player == 0){
			GameStats.scoreValuePOne /= 2;
		}
		else{
			GameStats.scoreValuePTwo /= 2;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);

	}

	public IEnumerator swapButtons(int player)
	{
		if(player == 0){ //player one
			originalOPosition = playerOneO.transform.localPosition;
			originalXPosition = playerOneX.transform.localPosition;
			playerOneO.transform.localPosition = originalXPosition;
			playerOneX.transform.localPosition = originalOPosition;
		}
		else{ //player 2
			originalOPosition = playerTwoO.transform.position;
			originalXPosition = playerTwoX.transform.position;
			playerTwoO.transform.position = originalXPosition;
			playerTwoX.transform.position = originalOPosition;
		}

		yield return new WaitForSecondsRealtime (powerupDuration);
			
		if(player == 0){
				playerOneO.transform.localPosition = originalOPosition;
				playerOneX.transform.localPosition = originalXPosition;
		}
		else{
				playerTwoO.transform.position = originalOPosition;
				playerTwoX.transform.position = originalXPosition;
		}
		//testSwap = false;

		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);

	}

	public IEnumerator disableButtons(int player)
	{
		if(player == 0){
			playerOneO.interactable = false;
			playerOneX.interactable = false;
		}
		else{
			playerTwoO.interactable = false;
			playerTwoX.interactable = false;
		}

		yield return new WaitForSecondsRealtime (powerupDuration);

		if(player == 0){
			playerOneO.interactable = true;
			playerOneX.interactable = true;
		}
		else{
			playerTwoO.interactable = true;
			playerTwoX.interactable = true;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);

	}

	public IEnumerator sharePoints(int player)
	{
		if(player == 0){
			pOneSharePTwo = true;
		}
		else{
			pTwoSharePOne = true;
		}
		yield return new WaitForSecondsRealtime (powerupDuration);

		if(player == 0){
			pOneSharePTwo = false;
		}
		else{
			pTwoSharePOne = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}

	public IEnumerator textRotation(int player)
	{
		if(player == 0){
			roatationPOne = true;
		}
		else{
			rotationPTwo = true;
		}
		yield return new WaitForSecondsRealtime(powerupDuration);
		if(player == 0){
			roatationPOne = false;
		}
		else{
			rotationPTwo = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}
	public IEnumerator textColorChange(int player)
	{
		if(player == 0){
			colorChangePOne = true;
		}
		else{
			colorChangePTwo = true;
		}
		yield return new WaitForSecondsRealtime(powerupDuration);
		if(player == 0){
			colorChangePOne = false;
		}
		else{
			colorChangePTwo = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}
	public IEnumerator textSizeChange(int player)
	{
		if(player == 0){
			sizeChangePOne = true;
		}
		else{
			sizeChangePTwo = true;
		}
		yield return new WaitForSecondsRealtime(powerupDuration);
		if(player == 0){
			sizeChangePOne = false;
		}
		else{
			sizeChangePTwo = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}
	public IEnumerator reverseText(int player)
	{
		if(player == 0){
			reverseTextPOne = true;
		}
		else{
			reverseTextPTwo = true;
		}
		yield return new WaitForSecondsRealtime(powerupDuration);
		if(player == 0){
			reverseTextPOne = false;
		}
		else{
			reverseTextPTwo = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}

	public IEnumerator moveText(int player)
	{
		if(player == 0){
			movePOne = true;
		}
		else{
			movePTwo = true;
		}
		yield return new WaitForSecondsRealtime(powerupDuration);
		if(player == 0){
			movePOne = false;
		}
		else{
			movePTwo = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}

	public IEnumerator blinkText(int player)
	{
		if(player == 0){
			blinkPOne = true;
		}
		else{
			blinkPTwo = true;
		}
		yield return new WaitForSecondsRealtime(powerupDuration);
		if(player == 0){
			blinkPOne = false;
		}
		else{
			blinkPTwo = false;
		}
		doOnce = true;
		GameStats.powerupActivated = false;
		gameObject.SetActive(false);
	}

}
