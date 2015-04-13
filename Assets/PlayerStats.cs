using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int playerHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth <= 0){
			GameOver();
		}
	}

	void GameOver(){

	}

	void OnCollisionEnter2D(Collision col){
		Debug.Log("Hello");
	}
}
