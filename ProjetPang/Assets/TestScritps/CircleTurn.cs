using UnityEngine;
using System.Collections;

public class CircleTurn : MonoBehaviour {

	float speed = 0;
	// Update is called once per frame
	void Update () {
		Debug.Log (speed);
		speed = 0.001f;
		transform.rotation = new Quaternion(0, 0, speed, 0);
	}
}
