using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string text = null;
	Vector2 temp;
	float halfScreenWidth, halfScreenHeight;
	bool moving;


	void Start () {
		halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
		halfScreenHeight = Camera.main.orthographicSize;
	}

//	void OnDrawGizmos () {
//		Gizmos.color = Color.blue;
//		Gizmos.DrawCube(new Vector2(-halfScreenWidth/2, 0), new Vector2(halfScreenWidth, halfScreenHeight * 2));
//	}

	void Update () {
		for (int i=0; i<Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);
			Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);

			if(position.x < 0) {
				MoveWeapon(touch, position);
				moving = true;
			}

			if(position.x > 0) {
				ShootWeapon(touch, position);
			}
		}
	}

	void MoveWeapon (Touch touch, Vector2 position) {
		if(touch.phase == TouchPhase.Began) {
			temp.x = transform.position.x - position.x;
			temp.y = transform.position.y - position.y;
		}

		if(touch.phase == TouchPhase.Moved) {
			Vector2 diff;
			diff.y = position.y + temp.y;
			diff.x = transform.position.x;
			transform.position = diff;

		}
	}

	void ShootWeapon (Touch touch, Vector2 position) {
		if(touch.phase == TouchPhase.Began) {
			temp.x = transform.position.x - position.x;
			temp.y = transform.position.y - position.y;
		}

		if(touch.phase == TouchPhase.Moved) {
			Debug.Log("Angle");
			Vector2 targetDir;
			targetDir.x = position.x - transform.position.x; //+ temp.x;
			targetDir.y = position.y - transform.position.y; //+ temp.y;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		}
	}
}
