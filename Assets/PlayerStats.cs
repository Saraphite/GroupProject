using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int playerHealth = 100;
	public int damageTaken = 0;
	public int triggerThreshold = 10;
	public bool limiter = false; // makes sure the virus events don't fire for as long as the player remains at a multiple of 10hp.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth <= 0){
			GameOver();
		}
		if(damageTaken != 0 && (damageTaken % triggerThreshold) == 0){
			//Enter the code to run batch script here.
			if(!limiter)
			Debug.Log ("Thing triggered");
			limiter = true;
		}
		else{
			limiter = false;
		}
	}

	void GameOver(){

	}

//	void DamagePlayer(int damageAmount){
//		playerHealth -= damageAmount;
//	}
}
