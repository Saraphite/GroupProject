using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public GameObject director;
	private WorldManager manager;
	public float timer;
	public int enemyLevel = 0;
	public GameObject[] enemies; //These should be elsewhere in the level and deactivated.
	public float delayDecay = 0.02f;
	public float spawnDelay = 2.0f;
	public int spawnCounter = 0;
	public int overallSpawnCount = 0;
	public int levelThreshold = 10;

	// Use this for initialization
	void Start () {
		timer = Time.time + 1;
		manager = director.GetComponent<WorldManager>();
	}
	
	// Update is called once per frame
	void Update(){ 
		if(timer < Time.time){ //Spawn enemy
			int randomIndex = Random.Range(0, (enemyLevel + 1));
			Debug.Log (enemyLevel);
			Debug.Log(randomIndex);
			GameObject spawnedEnemy = (GameObject)Instantiate(enemies[randomIndex], transform.position, transform.rotation);
			spawnedEnemy.SetActive (true);
			manager.activeEnemies.Add(spawnedEnemy);
			spawnCounter++;
			overallSpawnCount++;
			if(spawnCounter == levelThreshold && enemyLevel < enemies.Length){
				spawnCounter = 0;
				enemyLevel++;
				Debug.Log ("Enemy leveled up");
			}
			timer = Time.time + CalculateSpawnDelay();
		}
	}

	float CalculateSpawnDelay(){ //Returns float value for the time between spawn.
		spawnDelay -= delayDecay;
		if(spawnDelay < 0.2f){
			spawnDelay = 0.2f;
		}
		return spawnDelay;
	}
}
