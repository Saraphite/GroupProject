using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{
	public float speed;
	public int damage;
	public GameObject target;
	private EnemyAI targetStats;
	//private Rigidbody2D projectileRigid;
	public Vector3 lastpos;


	// Use this for initialization
	void Start ()
	{
		//Debug.Log ("Spawned projhectile");
		targetStats = target.GetComponent<EnemyAI>();
		//projectileRigid = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Quaternion.RotateTowards (transform.rotation, target.transform.rotation, 180.0f); //Theoretically this should be instant.
		//projectileRigid.AddForce((target.transform.position - transform.position) * speed);
		try{
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed *Time.deltaTime);
			transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
			if(Vector3.Distance (transform.position, target.transform.position) < 0.8f){
				targetStats.health -= damage;
				Destroy (gameObject);
			}
		}
		catch(MissingReferenceException e){
			Destroy (gameObject);
		}
	}
}

