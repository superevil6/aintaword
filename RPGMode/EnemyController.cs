using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
	// Use this for initialization
	public GameObject enemyGO;
	public List<int> enemySquad;
	int currentEnemy = 0;
	public Enemy enemy;
	public Player player;
	public EnemyDatabase ed;
	public Squad squad;
	public BattleController bc;
	public WordGeneration wg;
	public Text word;
	public AudioSource se;
	public AudioClip[] sounds;
	private float enemyAttackInterval = 0;

	/*
	0. attack
	1. death
	 */

	void Start()
	{
		//enemySquad = squad.enemyIndecies;
		foreach(int id in GameStats.enemyIds){
			enemySquad.Add(id);
		}
		getEnemyData(enemySquad[currentEnemy]); //This will be set based off the squad that's chosen.
	}

	void Update()
	{
		enemyAttackInterval += Time.deltaTime;
		word.text = GameStats.word;
		if(enemy.CurrentHealth <= 0 && !enemy.dead){
			StartCoroutine("enemyDeath");
			enemy.dead = true;
		}
		if(enemyAttackInterval >= enemy.Speed && !enemy.dead){
			player.CurrentHealth -= enemyAttack();
			enemyAttackInterval = 0;
		}

	}
	public void getEnemyData(int id)
	{
		enemy = ed.returnEnemyByID(id);
		enemySetup();
	}
	
	public void enemySetup()
	{
		wg.setWordList(enemy.WordList);
		enemyGO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(enemy.Sprite);
		enemy.CurrentHealth = enemy.MaxHealth;
		enemyGO.GetComponent<SpriteRenderer>().color = enemy.Color;  //Color.white;
		enemy.dead = false;
		wg.wordGeneration();
	}

	public IEnumerator enemyDeath(){
		enemyGO.GetComponent<SpriteRenderer>().color = Color.red;
		playSE(1);
		player.currentExperience += enemy.Expierence;
		GameStats.rpgUI.callDamageDisplay("+ " + enemy.Expierence.ToString() + " Experience\n+ " + enemy.Gold + " Gold", true, 2f);
		player.gold += enemy.Gold;
		yield return new WaitForSecondsRealtime(0.5f);
		enemyGO.GetComponent<SpriteRenderer>().color = Color.clear;
		yield return new WaitForSecondsRealtime(0.5f);
		if(enemySquad.Count - 1 > currentEnemy){
			currentEnemy++;
			getEnemyData(enemySquad[currentEnemy]);
			print(enemySquad[currentEnemy].ToString());
		}
		else{
			bc.victory = true;
		}
	}

	public int enemyAttack(){
		playSE(0);
		if(enemy.Attack - (player.Defense + player.armor.DefenseModifier) > 0){
			int damage = enemy.Attack - (player.Defense + player.armor.DefenseModifier);
			GameStats.rpgUI.callDamageDisplay(damage.ToString(), true, 0.75f);
			return damage;
		}
		else{
			return 0;
		}
	}

	public void playSE(int index){
		se.clip = sounds[index];
		se.Play();
	}
}
