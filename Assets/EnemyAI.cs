using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public int health = 5;
	public int attackPower = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Death();
		}
	}

	void Death(){
		Destroy(this);
	}
}
