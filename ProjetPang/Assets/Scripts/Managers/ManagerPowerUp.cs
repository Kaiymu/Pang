using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ManagerPowerUp : MonoBehaviour {

	private GameObject _powerUpBase;
	private Transform _childPowerUpBase;

	private ManagerArray _managerArray;

	// Called in manager array, to prevent the bug where the addPowerUpToArray doesn't exist
	public void OnGlobalEnable()
	{
		_managerArray = this.GetComponent<ManagerArray>();
		_powerUpBase = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>().powerUpContainer;
		// Looping throught my parent gameobject to retrieve all the childs.
		for(int i = 0; i < _powerUpBase.transform.childCount; i++)
		{
			_childPowerUpBase = _powerUpBase.transform.GetChild(i);
			
			//_managerArray.addPowerUpToArray(_childPowerUpBase.transform.gameObject);
		}

	}

	public void movementPowerUps(GameObject me, float speed)
	{
		me.transform.Translate(new Vector2(0, -speed) * Time.deltaTime);
	}

}