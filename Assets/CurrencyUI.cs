using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyUI : MonoBehaviour {

	Text currencyText;
	public GameObject player;
	PlayerStats stats;

	// Use this for initialization
	void Start () {
		stats = player.GetComponent<PlayerStats>();
		currencyText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		currencyText.text = stats.currency.ToString ();
	}
}
