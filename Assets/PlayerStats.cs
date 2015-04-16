using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

	public int playerHealth = 100;
	public int damageTaken = 0;
	public int triggerThreshold = 10;
	private bool limiter = false; // makes sure the virus events don't fire for as long as the player remains at a multiple of 10hp.
	SpriteRenderer characterSprite;
	public Sprite[] spriteList = new Sprite[4];
	public int currency = 70; //currency

	// Use this for initialization
	void Start () {
		characterSprite = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(damageTaken != 0 && (damageTaken % triggerThreshold) == 0){
			//Enter the code to run batch script here.
			if(!limiter)
			Debug.Log ("Thing triggered");
			limiter = true;
		}
		else{
			limiter = false;
		}
		if(playerHealth > 50){ //Health checks.
			characterSprite.sprite = spriteList[0];
		}
		else{
			if(playerHealth > 25){
				characterSprite.sprite = spriteList[1];
			}
			else{
				if(playerHealth > 0){
					characterSprite.sprite = spriteList[2];
				}
				else{
					characterSprite.sprite = spriteList[3];
					GameOver ();
				}
			}
		}


	}

	void GameOver(){

	}

//	void DamagePlayer(int damageAmount){
//		playerHealth -= damageAmount;
//	}
}
