using UnityEngine;
using System.Collections;

public abstract class LegacyPowerUpElements : DestroyOnWall {

	protected override void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			gameObject.SetActive(false);
			ActiveCollisionPlayer(col.gameObject);
		}

		base.OnTriggerEnter2D(col);
	}

	protected virtual void ActiveCollisionPlayer(GameObject player)
	{
		ManagerElements.instance.IDElement = GetComponent<GiveUniqueID>().IDGroup;
	}

}
