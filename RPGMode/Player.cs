using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Actor {
public DataManager data;
public ItemDatabase itemDatabase;
public int level;
public int gold;
public int currentExperience;
public Weapon weapon;
public Armor armor;
public List<Item> inventory = new List<Item>();
public List<Skills> activeSkills = new List<Skills>();
public Skill activeSkillOne;
public Skill activeSkillTwo;
public Skill weaponSkill;
public Skill ultimateSkill;
[SerializeField]
private GameObject skillBar;
[SerializeField] Button skillButtonPrefab;
public Class playerClass;
public enum Class {
Bard, 
Fencer,
Brute
}
	// Use this for initialization
	void Start () {
	skillBar = GameObject.FindGameObjectWithTag("SkillBar");
	data.loadGame();

		foreach(Skills _skill in knownSkills){
			Button skillButton = Instantiate(skillButtonPrefab);
			skillButton.transform.SetParent(skillBar.transform);
			skillButton.transform.localScale = new Vector2(1, 1);
			skillButton.GetComponentInChildren<Text>().text = _skill.sName;
			skillButton.image.GetComponent<Image>().sprite = _skill.sSprite;
			skillButton.onClick.AddListener(() => _skill.TriggerSkill(true));
			activeSkills.Add(_skill);
		}
		armor = itemDatabase.armorDatabase[0];
		weapon = itemDatabase.weaponDatabase[0];
		inventory.Add(armor);
		inventory.Add(weapon);
		print(weapon.Title);
	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0){
			// foreach(GameObject skill in skillBar.transform){
			// 	skill.SetActive(false); // = false;
			// }

			GameStats.gameOver = true;
		}
	}
}

