using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;



public class AdventureMode : MonoBehaviour {
	private WordGeneration wg;
	public List<Level> levels = new List<Level>();
	private JsonData levelData;
	public List<string> wordsToAdd;
	// Use this for initialization
	void Awake () {
		levelData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Levels.json"));
		ConstructLevelDatabase();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ConstructLevelDatabase()
	{
		
		//List<string> addTheseWords = new List<string>();
		for(int i = 0; i < levelData.Count; i++)
		{
			print(levelData[i]["wordsToAdd"][0]);
			foreach(JsonData _word in levelData[i]["wordsToAdd"]){
				wordsToAdd.Add(_word.ToString());
			}
			levels.Add(new Level(
				(int)levelData[i]["id"],
				levelData[i]["worldName"].ToString(),
				(int)levelData[i]["themeIndex"],
				levelData[i]["bgm"].ToString(),
				levelData[i]["wordListName"].ToString(),
				wordsToAdd,
				levelData[i]["levelIntroFlavorText"].ToString(),
				(bool)bool.Parse(levelData[i]["conditionPoints"].ToString()),
				(bool)bool.Parse(levelData[i]["conditionWords"].ToString()),
				(int)levelData[i]["points"],
				(int)levelData[i]["words"],
				(float)float.Parse(levelData[i]["timeLimit"].ToString()),
				levelData[i]["handicapOne"].ToString(),
				levelData[i]["handicapTwo"].ToString()
				
			));
		}
	}
}

public class Level{
public int ID {get; set;}
public string WorldName {get; set;}
public int ThemeIndex {get; set;}
public AudioClip BGM {get; set;}
public string WordListName {get; set;}
public List<string> WordsToAdd {get; set;}
public string LevelIntroFlavorText {get; set;}
public bool ConditionPoints {get; set;}
public bool ConditionWords {get; set;}
public int Points {get; set;}
public int Words {get; set;}
public float TimeLimit {get; set;}
public string HandicapOne {get; set;}
public string HandicapTwo {get; set;}

public Level(int id, string worldName, int themeIndex, string bgm, string wordListName, List<string> wordsToAdd, string levelIntroFlavorText, bool conditionPoints, bool conditionWords, int points, int words, float timeLimit, string handicapOne, string handicapTwo){
this.ID = id; 
this.WorldName = worldName;
this.ThemeIndex = themeIndex;
this.BGM = (AudioClip) Resources.Load(bgm);
this.WordListName = wordListName;
this.WordsToAdd = wordsToAdd;
this.LevelIntroFlavorText = levelIntroFlavorText;
this.ConditionPoints = conditionPoints;
this.ConditionWords = conditionWords;
this.Points = points;
this.Words = words;
this.TimeLimit = timeLimit;
this.HandicapOne = handicapOne;
this.HandicapTwo = handicapTwo;
}
}
