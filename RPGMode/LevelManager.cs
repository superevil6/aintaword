using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
public List<int> expTable = new List<int>();
public Player player;
public BattleController bc;
public DataManager data;
public int maxLevel;
// bool levelupOnce; //So level up doesn't happen twice.
	// Use this for initialization
	void Start () {
		for(int i = 0; i <= maxLevel; i++){
			expTable.Add(i * i + 10);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(bc.victory){
			checkForLevelUp();
			data.saveGame();
			UnityEngine.SceneManagement.SceneManager.LoadScene(6);
		}
	}
	public void checkForLevelUp(){
		if(player.currentExperience >= expTable[player.level]){
			player.currentExperience -= expTable[player.level];
			print("Remaining exp for next level: " + player.currentExperience.ToString());
			player.level += 1;
			levelUp();
		}
	}
	public void levelUp(){
		if(player.playerClass == Player.Class.Bard){
			int maxHealthIncrease = Random.Range(2, 6);
			int attackIncrease = Random.Range(2, 3);
			int defenseIncrease = Random.Range(3, 6);
			int magicIncrease = Random.Range(4, 8);
			int speedIncrease = Random.Range(6, 8);
			player.MaxHealth += maxHealthIncrease;
			player.Attack += attackIncrease;
			player.Defense += defenseIncrease;
			player.Magic += magicIncrease;
			player.Speed += speedIncrease;
			print("Good so far!");
		}
	}
}
