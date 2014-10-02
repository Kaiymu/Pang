using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the arrow GameObject
**  Make the arrow move & rotate in function of a passed vector. 
************************************************************************************************/

public class ArrowMovement : MonoBehaviour {

	private float _speed;

	public enum DirectionShootedArrow{Up, UpLeft, UpRight};
	public DirectionShootedArrow directionShootedArrow;

	private Vector2 _direction;
	public Quaternion _angleZ;

	void OnEnable()
	{
		_direction = transform.up;
		transform.rotation = _angleZ;
	}
	
	public float getSpeed()
	{
		return _speed;
	}
	
	public void setSpeed(float speed)
	{
		_speed = speed;
	}

	void FixedUpdate () 
	{
		this.transform.Translate(_direction * _speed * Time.deltaTime);
	}
}
