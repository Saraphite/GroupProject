using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour {

	public List<GameObject> activeEnemies;

	// Use this for initialization
	void Start () {
		activeEnemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
