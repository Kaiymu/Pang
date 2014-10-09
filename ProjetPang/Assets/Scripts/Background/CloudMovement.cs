using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the cloud Gameobject
**  Make the cloud move up and down to make a wind effect
************************************************************************************************/

public class CloudMovement : MonoBehaviour {
	
	public float speedX = 0.001f;
	public float speedY = 1.0f;

	private float _x = 10;
	private float _y;

	void Start()
	{
		_x = this.transform.position.x;
		_y = this.transform.position.y;
	}

	void Update () {

		_x -= speedX;
		_y = 1 + Mathf.Sin(Time.time) * 0.1f;
		Vector2 velocity = new Vector2(_x, _y);

		this.transform.position = velocity;
	}
}
