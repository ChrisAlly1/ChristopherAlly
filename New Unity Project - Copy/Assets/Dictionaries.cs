using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dictionaries : MonoBehaviour
{
	// Create Dictionary to hold GameObjects
	public Dictionary<string,int> SceneDictionary;
	
	// Create Array to hold GameObject names and values
	public string[] objectNames;
	public int[] objectCounts;
	
	//Use this for initialization
	void Start ()
	{
		// Lists all GameObject names in Scene
		SceneDictionary = new Dictionary<string, int>();
		GameObject[] gos =
			GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		
		// Goes through entire Array of found GameObjects
		foreach(GameObject go in gos)
		{
			// Check if GameObject already exists
			if(SceneDictionary.ContainsKey(go.name))
			{
				// Increase count if GameObject exists
				SceneDictionary[go.name] += 1;
			}
			else
			{
				// Add GameObject to Dictionary with a value of 1
				SceneDictionary.Add(go.name, 1);
			}
		}
		
		// Instantiate Array to hold all GameObject names found 
		objectNames = new string[SceneDictionary.Keys.Count];
		
		// Instantiate Array to hold all GameObject values found
		objectCounts = new int[SceneDictionary.Values.Count];
		
		// Copy contents of Dictionary to the Arrays created
		SceneDictionary.Keys.CopyTo(objectNames, 0);
		SceneDictionary.Values.CopyTo(objectCounts, 0);
	}
}
