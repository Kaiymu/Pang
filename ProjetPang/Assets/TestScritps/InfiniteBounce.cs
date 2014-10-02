using UnityEngine;
using System.Collections;

public class InfiniteBounce : MonoBehaviour {

	public float bounceSpeed = 1.0f;
	public float bounceAmount = 2.0f;

	void Update () {
		Vector3 test = transform.position;
		test.y = Bounce((Time.time * bounceSpeed)%1) * bounceAmount;
		transform.position = test;
	}

	float Bounce (float t) {
		return Mathf.Sin(Mathf.Clamp01(t) * Mathf.PI);
	}
}
