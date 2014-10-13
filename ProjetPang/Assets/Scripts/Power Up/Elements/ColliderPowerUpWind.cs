using UnityEngine;
using System.Collections;

public class ColliderPowerUpWind : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer(GameObject player)
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Wind;
	}
}
