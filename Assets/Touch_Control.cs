using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Touch_Control : MonoBehaviour {

	Text text;
	Player player;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(text.text != player.text) {
			text.text = player.text;
		}
	}
}
