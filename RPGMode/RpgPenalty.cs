using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RpgPenalty : MonoBehaviour {
public Button[] playerCommands;
public EnemyController ec;
public Player player;


public void initiatePenalty(){
	float duration = (ec.enemy.Pressure - player.Speed) / 10;
	if(duration <= 0){
		duration = 0.25f;
	}
	StartCoroutine(penalize(duration));
	GameStats.rpgUI.callDamageDisplay("Fumble!", true, duration);
}


private IEnumerator penalize(float duration){
	foreach(Button command in playerCommands){
		command.interactable = false;
	}
	yield return new WaitForSecondsRealtime(duration);
	foreach(Button command in playerCommands){
		command.interactable = true;
	}
}
}
