using UnityEngine;
using System.Collections;

public class PowerUpFire : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer()
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Fire;
	}
}
