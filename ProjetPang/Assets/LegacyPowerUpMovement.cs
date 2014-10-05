using UnityEngine;
using System.Collections;

/************************************************************************************************
* 
** Get the speed from the manager, and give it to the player
************************************************************************************************/

public abstract class LegacyPowerUpMovement : MonoBehaviour {

	public float speed;

	void FixedUpdate()
	{
		movementPowerUps();
	}

	protected virtual void movementPowerUps()
	{
		transform.Translate(new Vector2(0, -speed) * Time.deltaTime);
	}
}
