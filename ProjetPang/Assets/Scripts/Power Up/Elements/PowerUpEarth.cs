using UnityEngine;
using System.Collections;

public class PowerUpEarth : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer()
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Earth;
	}
}
