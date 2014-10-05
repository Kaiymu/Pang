using UnityEngine;
using System.Collections;

/************************************************************************************************
* 
** Get the speed from the manager, and give it to the player
************************************************************************************************/

public abstract class LegacyPowerUpMovement : MonoBehaviour {

	private float _speed;

	void FixedUpdate()
	{
		movementPowerUps();
	}

	public float speed
	{
		get { return _speed;}
		set { _speed = value;}
	}

	protected virtual void movementPowerUps()
	{
		transform.Translate(new Vector2(0, -_speed) * Time.deltaTime);
	}
}
