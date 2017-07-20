using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPGUIManager : MonoBehaviour {
public Image healthOrb;
public Image expIndicator;
public Player player;
public LevelManager lm;
public EnemyController enemy;
public Image enemyHealthBar;
public Text enemyName;
public Text expText;
public GameObject[] damageIndicators;
public float damageIndicatorDisplayTime;
	// Use this for initialization
	void Start () {
		GameStats.rpgUI = gameObject.GetComponent<RPGUIManager>();
		foreach(GameObject damageIndicator in damageIndicators){
			damageIndicator.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		expText.text = player.currentExperience.ToString() + " / " + lm.expTable[player.level].ToString();
		expIndicator.fillAmount = player.currentExperience/lm.expTable[player.level];
		enemyName.text = enemy.enemy.EnemyName;
		healthOrb.fillAmount = ((player.CurrentHealth * 1.0f)/(player.MaxHealth * 1.0f));
		enemyHealthBar.fillAmount = (enemy.enemy.CurrentHealth *1.0f) / (enemy.enemy.MaxHealth * 1.0f);
	}

public void callDamageDisplay(string damageAmount, bool playerTarget, float duration){ //This version is Skills, since they are scriptable objects they can not start Coroutines.
	StartCoroutine(displayDamage(damageAmount, playerTarget, damageIndicatorDisplayTime));
}
//Add in the location of the indicators
	public IEnumerator displayDamage(string damageAmount, bool playerTarget, float duration)
	{
		for(int i = 0; i <= damageIndicators.Length; i++){
			if(!damageIndicators[i].activeInHierarchy){
				damageIndicators[i].GetComponentInChildren<Text>().text = damageAmount.ToString();
				if(playerTarget){
					float xCoord = Random.Range(-50, 50);
					float yCoord = Random.Range(-600, -550);
					damageIndicators[i].transform.localPosition = new Vector2(xCoord, yCoord);
				}
				else{
					float xCoord = Random.Range(-50, 50);
					float yCoord = Random.Range(-50, 50);
					damageIndicators[i].transform.localPosition = new Vector2(xCoord, yCoord);
				}
				damageIndicators[i].SetActive(true);
				yield return new WaitForSecondsRealtime(duration);
				damageIndicators[i].SetActive(false);
				break;
			}
		}
	}
}
