using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswersRPG : MonoBehaviour {
	//public GameObject correctGraphic;
	//Use a weapon or monster object to supply the clips for attacking/getting hit.
	//public Text streakIndicator;
	public Player P;
	public EnemyController EC;
	public WordGeneration WG;
	public RPGUIManager UI;
	public RpgPenalty penalty;
	public GameObject skillBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkAnswerO()
	{
		if(!WordGeneration.modified){
			//Consider adding a score to this mode later?
			GameStats.streak += 1;
			addCharge();
			damageEnemy();
			WG.wordGeneration();
		}
		else{
			GameStats.streak = 0;
			penalty.initiatePenalty();
		}
	}
	public void checkAnswerX()
	{
		if(WordGeneration.modified){
			//Consider adding a score to this mode later?
			GameStats.streak += 1;
			damageEnemy();
			addCharge();
			print(EC.enemy.CurrentHealth.ToString());
			WG.wordGeneration();
		}
		else{
			GameStats.streak = 0;
			penalty.initiatePenalty();
		}
	}

	public void damageEnemy()
	{
		int damage = (P.Attack + P.weapon.AttackModifier) - EC.enemy.Defense;
		if(EC.enemy.ElementalStrength.ToString() ==  P.weapon.WeaponElement.ToString()){
			Mathf.RoundToInt(damage * 0.5f);
			print("strong!" + damage.ToString());
		}
		else if(EC.enemy.ElementalWeakness.ToString() == P.weapon.WeaponElement.ToString()){
			Mathf.RoundToInt(damage * 1.50f);
			print("weak!" + damage.ToString());
		}
		EC.enemy.CurrentHealth -= damage;
		StartCoroutine(UI.displayDamage(damage.ToString(), false, 0.75f));
	}	

	public void addCharge(){
		if(GameStats.streak >= 1){
			foreach(Skills skill in P.activeSkills){
				if(skill.currentCharge < skill.neededCharge){
					skill.currentCharge += 1;
				}
			}
		}
	}
}
