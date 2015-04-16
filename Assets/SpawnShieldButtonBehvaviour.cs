using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnShieldButtonBehvaviour : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject defenceUnit; //Unit to spawn.
	public GameObject unitInHand;
	public GameObject player;
	public Camera cam;
	private PlayerStats playerStats;
	public int cost;
	bool canPlace = false;
	Color unableColor;
	public float snapRange = 0.5f;

	// Use this for initialization
	void Start () {
		playerStats = player.GetComponent<PlayerStats>();
		unitInHand = null;
		unableColor = new Color(0.5f, 0 , 0 , 0.7f);

	}
	
	// Update is called once per frame
	void Update () {
		if(playerStats.currency >= cost){
			this.gameObject.GetComponent<Button>().interactable = true;
		}
		else{
			this.gameObject.GetComponent<Button>().interactable = false;
		}
		if(unitInHand != null){
			unitInHand.transform.position = GetPlacementProjection();
			if(unitInHand.transform.position == Vector3.zero){
				unitInHand.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
			else{
				unitInHand.gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
			if(Input.GetMouseButtonDown(0) && canPlace){
				GameObject newDef = Instantiate (unitInHand, GetPlacementProjection (), transform.rotation) as GameObject;
				newDef.GetComponent<BoxCollider>().enabled = true;
				//newDef.GetComponent<ShieldDefenceBehaviour>().enabled = true;
				newDef.layer = 8;
				playerStats.currency -= cost;
				Destroy(unitInHand);
				unitInHand = null;
				//Debug.Log ("Spawned");
			}	
			if(Input.GetMouseButtonDown (1) && unitInHand){
				Destroy(unitInHand);
				unitInHand = null;
			}
		}
	}

	public void OnClicked(){
		//Debug.Log ("Button Pressed");
		unitInHand = Instantiate (defenceUnit, GetPlacementProjection(), transform.rotation) as GameObject;
		unitInHand.GetComponent<BoxCollider>().enabled = false;
		unitInHand.layer = 0;
		unitInHand.SetActive(true);
		//SpawnAreaNotifications.SetActive (true);
	}

	Vector3 GetPlacementProjection(){
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Vector3 pos2d;
		if(Physics.Raycast (ray, out hit)){ //while it doesn't seem clean to do this check here, it means that there only has to be one raycast.
			if(unitInHand != null){
				GameObject waypoint = GetNearestWaypoint();
				Debug.Log (waypoint.name);
				//Debug.Log (hit.transform.gameObject.name);
				if(Vector3.Distance (waypoint.transform.position, unitInHand.transform.position) < snapRange){
					pos2d = waypoint.transform.position;
					unitInHand.GetComponent<SpriteRenderer>().color = Color.white;
					canPlace = true;
					return pos2d;
				}
				else{
					unitInHand.GetComponent<SpriteRenderer>().color = unableColor;
					canPlace = false;
				}
			}
			pos2d = new Vector3(hit.point.x, hit.point.y, -0.5f);
			return pos2d;
		}
		return Vector3.zero;
	}

	GameObject GetNearestWaypoint(){
		float bestDist = Mathf.Infinity;
		GameObject closestWP = null;
		foreach(GameObject wp in waypoints){
			float dist = Vector3.Distance(unitInHand.transform.position, wp.transform.position);
			if (dist < bestDist){
				closestWP = wp;
				bestDist = dist;
			}
		}
		return closestWP;
	}
}
