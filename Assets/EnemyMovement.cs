using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public GameObject[] waypoints;
	public int waypointIndex;
	public Vector3 target;
	public float speed = 2;

	// Use this for initialization
	void Start () {
		waypointIndex = 1;
		target = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		if(transform.position == target && waypointIndex != 8){
			waypointIndex++;
			target = waypoints[waypointIndex].transform.position;
		}
	}
	void OnCollisionEnter2D (Collision2D col){

	}

}
