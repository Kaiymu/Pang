using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the power up
** Get the speed from the manager, and give it to the player
************************************************************************************************/

public class PowerUpSetSpeed : MonoBehaviour {

	public float speed;

	private ManagerPowerUp _managerPowerUp;

	void OnEnable()
	{
		_managerPowerUp = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerPowerUp>();
	}
	void FixedUpdate()
	{
		_managerPowerUp.movementPowerUps(this.gameObject, speed);
	}
}
