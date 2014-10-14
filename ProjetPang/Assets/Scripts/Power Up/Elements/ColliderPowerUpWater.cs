using UnityEngine;
using System.Collections;

public class ColliderPowerUpWater : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer(GameObject player)
	{
		base.ActiveCollisionPlayer(player);
		ManagerElements.instance.currentElement = ManagerElements.Elements.Water;
	}
}
