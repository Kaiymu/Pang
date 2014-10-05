using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the arrow GameObject
**  Make the arrow move & rotate in function of a passed vector. 
************************************************************************************************/

public class ArrowMovement : MonoBehaviour {

	private float _speed;
	
	private Vector2 _direction;

	void OnEnable()
	{
		_direction = transform.up;
	}
	
	public float speed
	{
		get {return _speed;}
		set {_speed = value;}
	}

	void FixedUpdate () 
	{
		this.transform.Translate(_direction * _speed * Time.deltaTime);
	}
}
