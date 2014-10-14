using UnityEngine;
using System.Collections;

public abstract class LegacyPowerUpElements : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			gameObject.SetActive(false);
			ActiveCollisionPlayer(col.gameObject);
		}

		if(col.gameObject.tag == "Wall")
			gameObject.SetActive(false);

	}

	protected virtual void ActiveCollisionPlayer(GameObject player)
	{
		ManagerElements.instance.IDElement = GetComponent<GiveUniqueID>().ID;
	}

}
