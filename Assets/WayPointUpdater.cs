using UnityEngine;
using System.Collections;

public class WayPointUpdater : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Contains("WayPoint")){
			if(gameObject.GetComponentInParent<EnemyAI>().waypointIndex != 8)
			gameObject.GetComponentInParent<EnemyAI>().waypointIndex++;
		}
	}
}
