using UnityEngine;
using System.Collections;

public class ColliderPowerUpFire : LegacyPowerUpElements {

	protected override void ActiveCollisionPlayer(GameObject player)
	{
		ManagerElements.instance.currentElement = ManagerElements.Elements.Fire;
	}
}
