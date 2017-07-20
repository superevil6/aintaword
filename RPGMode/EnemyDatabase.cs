using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class EnemyDatabase : MonoBehaviour 
{
	private List<Enemy> enemyDatabase = new List<Enemy>();
	private JsonData enemyData;
	public List<string> wordsToAdd;

	void Start(){
		enemyData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Enemies.json"));
		ConstructEnemyDatabase();
	}

	void ConstructEnemyDatabase()
	{
		for(int i = 0; i < enemyData.Count; i++)
		{
			foreach(JsonData _word in enemyData[i]["wordsToAdd"]){
				wordsToAdd.Add(_word.ToString());
			}
		enemyDatabase.Add(new Enemy(
			(int)enemyData[i]["id"], 
			enemyData[i]["enemyName"].ToString(),
			(int)enemyData[i]["enemyLevel"],
			enemyData[i]["wordList"].ToString(),
			wordsToAdd,
			(int)enemyData[i]["maxHealth"],
			(int)enemyData[i]["attack"],
			(int)enemyData[i]["defense"],
			(float)float.Parse(enemyData[i]["speed"].ToString()),
			(float)float.Parse(enemyData[i]["pressure"].ToString()),
			(int)enemyData[i]["gold"],
			(int)enemyData[i]["experience"],
			enemyData[i]["sprite"].ToString(),
			enemyData[i]["color"].ToString(),
			(Enemy.Element)System.Enum.Parse(typeof (Enemy.Element), enemyData[i]["elementalStrength"].ToString()),
			(Enemy.Element)System.Enum.Parse(typeof (Enemy.Element), enemyData[i]["elementalWeakness"].ToString())

		));
		}
	}
	
	public Enemy returnEnemyByID(int id)
	{
	for(int i = 0; i < enemyDatabase.Count; i++)
	{
		if(enemyDatabase[i].ID == id)
		{
			return enemyDatabase[i];
		}
	}
	return null;
	}
	public int returnEnemyIdByLevel(int level){
		List<int> qualifyingMonsters = new List<int>();
		for(int i = 0; i < enemyDatabase.Count; i++){
			if(enemyDatabase[i].EnemyLevel >= (level -10) || enemyDatabase[i].EnemyLevel <= (level + 10)){
				qualifyingMonsters.Add(enemyDatabase[i].ID);
			}			
		}
		int monsterId = Random.Range(0, qualifyingMonsters.Count);
		return monsterId;
	}

	public string returnEnemyNameById(int id){
		for(int i = 0; i < enemyDatabase.Count; i++){
			if(enemyDatabase[i].ID == id){
				return enemyDatabase[i].EnemyName;
			}
		}
		return null;
	}
}

public class Enemy : Actor {
	public int ID {get; set;}
	public string EnemyName {get; set;}
	public int EnemyLevel {get; set;}
	public string WordList {get; set;}
	public List<string> WordsToAdd {get; set;}
	public float Pressure {get; set;}
	public int Gold {get; set;}
	public int Expierence {get; set;}
	public string Sprite {get; set;}
	public Color Color {get; set;}
	public bool dead = false;
	// Use this for initialization
public Enemy(int id, string enemyName, int enemyLevel, string wordList, List<string> wordsToAdd, int maxHealth, int attack, int defense, float speed, float pressure, int gold, int experience, string sprite, string color, Element elementalStrength, Element elementalWeakness ){
	this.ID = id;
	this.EnemyName = enemyName;
	this.EnemyLevel = enemyLevel;
	this.WordList = wordList;
	this.MaxHealth = maxHealth;
	this.Attack =  attack;
	this.Defense = defense;
	this.Speed = speed;
	this.Pressure = pressure;
	this.Gold = gold;
	this.Expierence = experience;
	this.Sprite = sprite;
	Color enemyColor;
	ColorUtility.TryParseHtmlString(color, out enemyColor);
	this.Color = enemyColor;

	this.ElementalStrength = elementalStrength;
	this.ElementalWeakness = elementalWeakness;
}
public Enemy(int id, string enemyName, int enemyLevel, string wordList, List<string> wordsToAdd, int maxHealth, int attack, int defense, float speed, float pressure, int gold, int experience, string sprite, string color){
	this.ID = id;
	this.EnemyName = enemyName;
	this.EnemyLevel = enemyLevel;
	this.WordList = wordList;
	this.WordsToAdd = wordsToAdd;
	this.MaxHealth = maxHealth;
	this.Attack =  attack;
	this.Defense = defense;
	this.Speed = speed;
	this.Pressure = pressure;
	this.Gold = gold;
	this.Expierence = experience;
	this.Sprite = sprite;
	// this.GetComponent<SpriteRenderer>().color = enemyColor;
}	


}
