using UnityEngine;
using System.Collections;

public class ArcherTowerBehaviour : MonoBehaviour {

	public GameObject projectile;
	float projectileSpeed = 5.0f;
	float lastShot;

	public float attackSpeed = 1.5f;
	public int attackDamage = 1;
	public float attackRange = 1.0f;
	public GameObject target;
	public EnemyAI enemyTarget;
	public float distanceToTarget;
	public GameObject director;
	public WorldManager manager;

	// Use this for initialization
	void Start()  {
		//Debug.Log ("Ping");
		manager = director.GetComponent<WorldManager>();
		lastShot = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(target == null){
			target = FindTarget();
		}
		else{
			distanceToTarget = Vector3.Distance (target.transform.position, this.gameObject.transform.position);
			if(Time.time > attackSpeed + lastShot && distanceToTarget < attackRange){
				//Debug.Log ("(Fired)");
				GameObject tempProjectile = Instantiate (projectile, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
				ProjectileBehaviour pb = tempProjectile.GetComponent<ProjectileBehaviour>();
				pb.speed = projectileSpeed;
				pb.target = target;
				pb.damage = attackDamage;
				tempProjectile.SetActive (true);
				lastShot = Time.time;
			}
			else{ //Must have moved out of range.
				target = FindTarget ();
			}
		}
	}

	GameObject FindTarget(){
		//Debug.Log ("Finding target");
		GameObject closestTarget = null;
		float bestDist = Mathf.Infinity;
		foreach(GameObject enemy in manager.activeEnemies){
			distanceToTarget = Vector3.Distance (enemy.transform.position, this.gameObject.transform.position);
			//Debug.Log ("currdist" + distanceToTarget);
			//Debug.Log ("bestdist" + bestDist);
			if(bestDist > distanceToTarget){
				bestDist = distanceToTarget;
				closestTarget = enemy;
			}
		}

		if(closestTarget != null){
			enemyTarget = closestTarget.GetComponent<EnemyAI>();
		}
		return closestTarget;
	}

}
