using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaBattle{
public string Title {get; set;}
public int AverageLevel {get; set;} //Average of all the monsters' levels.
public int GoldReward {get; set;}
public List<int> EnemyIds {get; set;}

public ArenaBattle(List<int> enemyIds, string title, int averageLevel, int goldReward) {
	this.Title = title;
	this.AverageLevel = averageLevel;
	this.GoldReward = goldReward;
	this.EnemyIds = enemyIds;
}
}
public class AreanaManager : MonoBehaviour {
public Player player;
public EnemyController ec;
public EnemyDatabase ed;
public GameObject scrollRect;
public List<ArenaBattle> availableBattles = new List<ArenaBattle>();
public Button battlePrefab; //This will display the generated available battles.
[SerializeField] private int numberOfAvailbleBattles;
private List<int> tempIds = new List<int>();

void Start()
{
	generateBattles();
}
public void generateBattles(){
	for(int i = 0; i <= numberOfAvailbleBattles; i++){
		availableBattles.Add(new ArenaBattle(enemyIds(player.level), createTitle(tempIds), 3, 2));	
		tempIds.Clear();
	}
	foreach(ArenaBattle battle in availableBattles){
		Button battleButton = Instantiate(battlePrefab);
		Text battleTitle = battleButton.transform.Find("Battle Title").GetComponent<Text>();
		battleTitle.text = battle.Title;
		Text battleAverageLevel = battleButton.transform.Find("Average Level").GetComponent<Text>();
		battleAverageLevel.text = battle.AverageLevel.ToString();
		battleButton.transform.SetParent(scrollRect.transform, false);
		battleButton.onClick.AddListener(() => startBattle(battle.EnemyIds));
	}
}
private List<int> enemyIds(int level){
	List<int> ids = new List<int>();
	int monsterCount = Random.Range(1, 5);
	for(int j = 0; j < monsterCount; j++){
		ids.Add(ed.returnEnemyIdByLevel(player.level));
		tempIds.Add(ids[j]);
		}
	return ids;
}

private string createTitle(List<int> ids){
	string title = "";
	foreach(int id in ids){
		title += ed.returnEnemyNameById(id);
		title += "\n";
	}
	return title;
}

public void startBattle(List<int> enemyIds){
	GameStats.enemyIds = enemyIds;
	UnityEngine.SceneManagement.SceneManager.LoadScene(7);
}
}
