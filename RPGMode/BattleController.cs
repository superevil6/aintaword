using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {
public DataManager data;
public Player player;
public Enemy E;
public EnemySquad ES;
public Skill S;
public Item I;
public RPGUIManager rpgUI;
public Button O;
public Button X;

private int enemyNumber;
private float enemyActionSpeed;
public Enemy currentEnemy;
public int squadIndex;
public bool victory = false;
public bool defeat;
	// Use this for initialization
	void Start () {
		player.CurrentHealth = player.MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(victory){
			rpgUI.enemyName.text = "Victory!";
			O.interactable = false;
			X.interactable = false;

		}
		

		if(GameStats.gameOver){
			O.interactable = false;
			X.interactable = false;
			rpgUI.enemyName.text = "Defeat...";
		}

	}

}