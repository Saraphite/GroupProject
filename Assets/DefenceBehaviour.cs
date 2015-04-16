using UnityEngine;
using System.Collections;

public class DefenceBehaviour : MonoBehaviour {
	
	public float attackSpeed = 1.5f;
	public int attackDamage = 1;
	public float attackRange = 12.0f;
	public GameObject target;
	public EnemyAI enemyTarget;

	public GameObject director;
	public WorldManager manager;

	// Use this for initialization
	protected virtual void Start () {
		manager = director.GetComponent<WorldManager>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if(target != null){

		}
		else{
			target = FindTarget();
		}
	}

	protected virtual GameObject FindTarget(){
		Debug.Log ("Finding target");
		GameObject closestTarget = null;
		float bestDist = Mathf.Infinity;
		foreach(GameObject enemy in manager.activeEnemies){
			float dist = Vector3.Distance (enemy.transform.position, this.gameObject.transform.position);
			if(bestDist > dist){
				bestDist = dist;
				closestTarget = enemy;

			}
		}

		if(closestTarget != null){
			Debug.Log ("Found target");
		}
		else{
			Debug.Log ("Found not target");
		}
		return closestTarget;
	}
	
}
