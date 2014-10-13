using UnityEngine;
using System.Collections;

public class ColliderPowerUpEarth : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer(GameObject player)
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Earth;
	}
}
