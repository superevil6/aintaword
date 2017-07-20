using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Squad
{
	public string squadName;
	public List<int> enemyIndecies; 
}
public class EnemySquad : MonoBehaviour {
	public List<Squad> squads;
	public int index;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
