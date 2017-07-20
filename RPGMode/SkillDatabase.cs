using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class SkillDatabase : MonoBehaviour {
private List<Skill> skillDatabase = new List<Skill>();
private JsonData skillData;
	// Use this for initialization
	void Start () {
		skillData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Skills.json"));
		ConstructSkillDatabase();
	}

	void ConstructSkillDatabase()
	{
		for(int i = 0; i < skillData.Count; i++)
		{
			skillDatabase.Add(new Skill(
				(int)skillData[i]["id"],
				skillData[i]["skillName"].ToString(),
				skillData[i]["description"].ToString(),
				(int)skillData[i]["cost"],
				float.Parse(skillData[i]["effectiveness"].ToString())
				)
				);
		}
	}	
}


public class Skill{
	public int ID {get; set;}
	public string Description{get; set;}
	public string SkillName {get; set;}
	public int Cost {get; set;}
	public float Effectiveness {get; set;}


public Skill(int id, string skillName, string description, int cost, float effectiveness){
this.ID = id;
this.SkillName = skillName;
this.Description = description;
this.Cost = cost;
this.Effectiveness = effectiveness;
}
}