using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAndDebuff : MonoBehaviour {
public enum Stats{
	Attack,
	Defense,
	Magic,
	Speed,
	MaximumHealth
}
Actor target;
public Stats effector; //This is the stat effected by the buff/debuff
public void applyBuffOrDebuff(Actor target, string effector, bool increase, float amount, float durration){
StartCoroutine(alterStat(target, effector, increase, amount, durration));
}

IEnumerator alterStat(Actor target, string effector, bool increase, float amount, float durration){
	if(effector == "Attack"){
		int tempAttack = target.Attack; //So it can be returned properly at the end of the effect. Be sure to account for the battle ending prematurely.
		if(increase){
			target.Attack = Mathf.RoundToInt(target.Attack * amount);
		}
		else{
			target.Attack = Mathf.RoundToInt(target.Attack * amount -  target.Attack);
			print("Target's attack is now " + target.Attack.ToString());
		}
		yield return new WaitForSecondsRealtime(durration);
		target.Attack = tempAttack;	
		print("Time's up, attack is now " + target.Attack.ToString());
	}
	if(effector == "Defense"){
		int tempDefense = target.Defense;
		if(increase){
			target.Defense = Mathf.RoundToInt(target.Defense * amount);
		}
		else{
			target.Defense = Mathf.RoundToInt(target.Defense * amount - target.Defense);
		}
		yield return new WaitForSecondsRealtime(durration);
		target.Defense = tempDefense;	
	}
	if(effector == "Magic"){
		int tempMagic = target.Magic;
		if(increase){
			target.Magic = Mathf.RoundToInt(target.Magic * amount);
		}
		else{
			target.Magic = Mathf.RoundToInt(target.Magic * amount - target.Magic);
		}
		yield return new WaitForSecondsRealtime(durration);
		target.Magic = tempMagic;	
	}
	if(effector == "Speed"){
		float tempSpeed = target.Speed;
		if(increase){
			target.Speed = target.Speed * amount;
		}
		else{
			target.Speed = target.Speed * amount - target.Speed;
		}
		yield return new WaitForSecondsRealtime(durration);
		target.Speed = tempSpeed;	
	}

}
}
