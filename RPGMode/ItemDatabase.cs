using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
private List<Item>itemDatabase = new List<Item>();
public List<Weapon>weaponDatabase = new List<Weapon>();
public List<Armor>armorDatabase = new List<Armor>();
private JsonData itemData;
private JsonData weaponData;
private JsonData armorData;
	// Use this for initialization
	void Start () {
		
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase();
		weaponData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Weapons.json"));
		ConstructWeaponDatabase();
		armorData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Armor.json"));
		ConstructArmorDatabase();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Weapon returnWeaponByLevel(int level){
		List<int> qualifyingWeapons = new List<int>();
		for(int i = 0; i < weaponDatabase.Count; i++){
			if(weaponDatabase[i].RequiredLevel >= (level - 10) || weaponDatabase[i].RequiredLevel <= (level + 10)){
				qualifyingWeapons.Add(weaponDatabase[i].ID);
				print("Added " + weaponDatabase[i].Title);
			}
		}
		int weaponId = Random.Range(0, qualifyingWeapons.Count);
		Weapon weapon = returnWeaponById(weaponId);
		return weapon;
	}
	public Armor returnArmorByLevel(int level){
		int upperBounds = level + 10;
		int lowerBounds = level - 10;
		print(armorDatabase.Count.ToString());
		List<int> qualifyingArmor = new List<int>();
		for(int i = 0; i < armorDatabase.Count; i++){
			// if(armorDatabase[i].RequiredLevel >= lowerBounds && armorDatabase[i].RequiredLevel >= upperBounds){
			// 	print(armorDatabase[i].ID.ToString());
			// 	qualifyingArmor.Add(armorDatabase[i].ID);
			// }
							qualifyingArmor.Add(armorDatabase[i].ID);

		}
		int armorId = Random.Range(0, qualifyingArmor.Count);
		Armor armor = returnArmorById(armorId);
		return armor;
	}
	public Weapon returnWeaponById(int id){
		for(int i = 0; i < weaponDatabase.Count; i++){
			if(weaponDatabase[i].ID == id){
				return weaponDatabase[i];
			}
		}
		return null;
	}
	public Armor returnArmorById(int id){
		for(int i = 0; i < armorDatabase.Count; i++){
			if(armorDatabase[i].ID == id){
				return armorDatabase[i];
			}
		}
		return null;
	}
	void ConstructItemDatabase()
	{
		for(int i = 0; i < itemData.Count; i++){
			itemDatabase.Add(new Item(
				(int)itemData[i]["id"], 
				itemData[i]["title"].ToString(), 
				itemData[i]["description"].ToString(),
				(int)itemData[i]["requiredLevel"],
				(int)itemData[i]["gold"],
				(bool)bool.Parse(itemData[i]["sellable"].ToString()),
				(int)itemData[i]["dropRate"],
				(bool)bool.Parse(itemData[i]["stackable"].ToString())
				 ));
		}
	}
	void ConstructWeaponDatabase(){
		for(int i = 0; i < weaponData.Count; i++){
			weaponDatabase.Add(new Weapon(
				(int)weaponData[i]["id"], 
				weaponData[i]["title"].ToString(), 
				weaponData[i]["description"].ToString(),
				(int)weaponData[i]["requiredLevel"],
				(int)weaponData[i]["gold"],
				(bool)bool.Parse(weaponData[i]["sellable"].ToString()),
				(int)weaponData[i]["dropRate"],
				(bool)bool.Parse(weaponData[i]["stackable"].ToString()),
				(int)weaponData[i]["attackModifier"],
				(int)weaponData[i]["magicModifier"],
				(Weapon.Element)System.Enum.Parse(typeof (Weapon.Element), weaponData[i]["weaponElement"].ToString())
			));
		}
	}
	void ConstructArmorDatabase(){
		for(int i = 0; i < armorData.Count; i++){
			armorDatabase.Add(new Armor(
				(int)armorData[i]["id"], 
				armorData[i]["title"].ToString(), 
				armorData[i]["description"].ToString(),
				(int)armorData[i]["requiredLevel"],
				(int)armorData[i]["gold"],
				(bool)bool.Parse(armorData[i]["sellable"].ToString()),
				(int)armorData[i]["dropRate"],
				(bool)bool.Parse(armorData[i]["stackable"].ToString()),
				(int)armorData[i]["defenseModifier"],
				(int)armorData[i]["magicDefenseModifier"],
				(int)armorData[i]["healthBoost"],
				(Armor.Element)System.Enum.Parse(typeof (Armor.Element), armorData[i]["armorElement"].ToString())
			));
		}
	}	
}
public class Item {
public int ID {get; set;}
public string Title {get; set;}
public string Description {get; set;}
public int RequiredLevel {get; set;}
public int Gold {get; set;}
public bool Sellable {get; set;}
public int DropRate {get; set;}
public bool Stackable {get; set;}

public Item(int id, string title, string description, int requiredLevel, int gold, bool sellable, int dropRate, bool stackable){
	this.ID = id;
	this.Title = title;
	this.Description = description;
	this.RequiredLevel = requiredLevel;
	this.Gold = gold;
	this.Sellable = sellable;
	this.DropRate = dropRate;
	this.Stackable = stackable;
}
}

public class Weapon : Item {
public int AttackModifier {get; set;}
public int MagicModifier {get; set;}
public Skills WeaponSkill {get; set;}
public Element WeaponElement {get; set;}
public enum Element{
	fire,
	ice,
	lightning,
	none
}

public Weapon(int id, string title, string description, int requiredLevel, int gold, bool sellable, int dropRate, bool stackable, int attackModifier, int magicModifier, Element element) : base (id,  title,  description, requiredLevel, gold,  sellable,  dropRate, stackable) {
	this.ID = id;
	base.Title = title;
	base.Description = description;
	base.RequiredLevel = RequiredLevel;
	base.Gold = gold;
	base.Sellable = sellable;
	base.DropRate = dropRate;
	base.Stackable = stackable;
	this.AttackModifier = attackModifier;
	this.MagicModifier = magicModifier;
	this.WeaponElement = element;
}
	
}

public class Armor : Item {
public int DefenseModifier {get; set;}
public int MagicDefenseModifier {get; set;}
public int HealthBoost {get; set;}
public Element ArmorElement {get; set;}
public enum Element{
	fire,
	ice,
	lightning,
	none
}
public Armor(int id, string title, string description, int requiredLevel, int gold, bool sellable, int dropRate, bool stackable, int defenseModifier, int magicDefenseModifier, int healthBoost, Element armorElement) : base (id,  title,  description, requiredLevel,  gold,  sellable,  dropRate, stackable) {
	this.ID = id;
	base.Title = title;
	base.Description = description;
	base.RequiredLevel = requiredLevel;
	base.Gold = gold;
	base.Sellable = sellable;
	base.DropRate = dropRate;
	base.Stackable = stackable;
	this.DefenseModifier = defenseModifier;
	this.MagicDefenseModifier = magicDefenseModifier;
	this.HealthBoost = healthBoost;
	this.ArmorElement = armorElement;
}

}