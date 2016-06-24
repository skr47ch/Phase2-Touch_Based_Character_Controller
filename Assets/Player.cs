using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string text = null;
	Vector2 temp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);

			if(touch.phase == TouchPhase.Began) {
				Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
				temp.x = transform.position.x - position.x;
				temp.y = transform.position.y - position.y;
			}

//			if(touch.phase == TouchPhase.Ended && touch.tapCount == 1) {
//				text = "Tap";
//				Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
//				transform.position = position;
//			}

			if(touch.phase == TouchPhase.Moved) {
				text = "Drag";
				Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
				transform.position = position + temp;

			}
		}
	}
}
