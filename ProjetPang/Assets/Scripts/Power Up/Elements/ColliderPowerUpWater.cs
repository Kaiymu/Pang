using UnityEngine;
using System.Collections;

public class ColliderPowerUpWater : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer(GameObject player)
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Water;
	}
}
