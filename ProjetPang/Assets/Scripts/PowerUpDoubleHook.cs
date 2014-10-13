using UnityEngine;
using System.Collections;

public class PowerUpDoubleHook : LegacyPowerUpElements {
	
	protected override void ActiveCollisionPlayer(GameObject player)
	{
		player.GetComponent<PlayerShoot>().numberArrowOnGame = 1;
	}
}
