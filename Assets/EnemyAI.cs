﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public GameObject director;
	public WorldManager manager;
	public GameObject[] waypoints;
	public int waypointIndex;
	public Vector3 target;
	public Rigidbody2D rigidbody;
	public int health = 3;
	public int attackPower = 1;
	public float speed = 2;
	private PlayerStats playerStats;
	public GameObject player;

	// Use this for initialization
	void Start () {
		manager = director.GetComponent<WorldManager>();
		waypointIndex = 1;
		target = waypoints[waypointIndex].transform.position;
		rigidbody = this.GetComponent<Rigidbody2D>();
		playerStats = player.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		//rigidbody.AddForce ((target - transform.position) * speed * Time.deltaTime);
		if(health <= 0){
			Death();
		}
		if(transform.position == target && waypointIndex != 8){
			waypointIndex++;
			target = waypoints[waypointIndex].transform.position;
		}
		if(transform.position == waypoints[8].transform.position){
			playerStats.playerHealth -= attackPower;
			playerStats.damageTaken += attackPower;
			Death ();
		}
	}



	void Death(){
		manager.activeEnemies.Remove (gameObject);
		Destroy(gameObject);
	}
}
