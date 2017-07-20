using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
class Data{
	public Player.Class playerClass;
	public int playerLevel;
	public int gold;
	public int currentExperience;
	public int weaponId;
	public int armorId;
	public List<int> inventoryById;
	public int maxHealth;
	public int attack;
	public int defense;
	public int magic;
	public float speed;

}
public class DataManager : MonoBehaviour {
	public Player player;
	public ItemDatabase item;

	void Start()
	{
		player = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		item = (ItemDatabase)GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
	}
	public void saveGame(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/data.ss");
		Data data = new Data();
		data.playerClass = player.playerClass;
		data.playerLevel = player.level;
		data.gold = player.gold;
		data.currentExperience = player.currentExperience;
		data.weaponId = player.weapon.ID;
		data.armorId = player.armor.ID;
		data.maxHealth = player.MaxHealth;
		data.attack = player.Attack;
		data.defense = player.Defense;
		data.magic = player.Magic;
		data.speed = player.Speed;

		bf.Serialize(file, data);
		file.Close();
	}

	public void loadGame(){
		if(File.Exists(Application.persistentDataPath + "/data.ss")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/data.ss", FileMode.Open);
			Data data = (Data)bf.Deserialize(file);
			player.playerClass = data.playerClass;
			player.level = data.playerLevel;
			player.gold = data.gold;
			player.currentExperience = data.currentExperience;
			player.weapon = item.returnWeaponById(data.weaponId);
			player.armor = item.returnArmorById(data.armorId);
			player.MaxHealth = data.maxHealth;
			player.Attack = data.attack;
			player.Defense = data.defense;
			player.Magic = data.magic;
			player.Speed = data.speed;

			file.Close();
		}
	}
}
