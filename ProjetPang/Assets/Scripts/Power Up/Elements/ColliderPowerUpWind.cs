using UnityEngine;
using System.Collections;

public class ColliderPowerUpWind : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer(GameObject player)
	{
		base.ActiveCollisionPlayer(player);
		ManagerElements.instance.currentElement = ManagerElements.Elements.Wind;
	}
}
