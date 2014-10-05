using UnityEngine;
using System.Collections;

public class PowerUpWater : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer()
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Water;
	}
}
