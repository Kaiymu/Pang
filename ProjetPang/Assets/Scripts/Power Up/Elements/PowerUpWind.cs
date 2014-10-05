using UnityEngine;
using System.Collections;

public class PowerUpWind : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer()
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Wind;
	}
}
