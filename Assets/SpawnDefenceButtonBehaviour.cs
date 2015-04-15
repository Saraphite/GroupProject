using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnDefenceButtonBehaviour : MonoBehaviour {

	public GameObject defenceUnit; //Unit to spawn.
	public GameObject unitInHand;
	public GameObject player;
	public Camera cam;
	private PlayerStats playerStats;
	public int cost;
	bool canPlace = false;
	Color unableColor;

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
		}
	}

	public void OnClicked(){
		Debug.Log ("Button Pressed");
		unitInHand = Instantiate (defenceUnit, GetPlacementProjection(), transform.rotation) as GameObject;
	}

	Vector3 GetPlacementProjection(){
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast (ray, out hit)){ //while it doesn't seem clean to do this check here, it means that there only has to be one raycast.
			if(unitInHand != null){
			if(hit.transform.gameObject.tag == "SpawnArea"){
				unitInHand.GetComponent<SpriteRenderer>().color = Color.white;
				canPlace = true;
			}
			else{
				unitInHand.GetComponent<SpriteRenderer>().color = unableColor;
				canPlace = false;
			}
			}
			Vector3 pos2d = new Vector3(hit.point.x, hit.point.y, -0.5f);
			return pos2d;
		}
		return Vector3.zero;
	}
}
