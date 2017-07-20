using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
public int CurrentHealth;
public int MaxHealth;
public int Attack;
public int Defense;
public int Magic;
public float Speed;
public List<Skills> knownSkills;
public Element ElementalWeakness;
public Element ElementalStrength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public enum Element{
		fire, 
		ice,
		lightning,
		none
	}
}
