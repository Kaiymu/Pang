using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPowerUp : MonoBehaviour {

	public int ammountPooledObject;

	private string _pooledParentObjectTagName = "PooledPowerUp";
	private GameObject _powerUpContainer;
	private List<GameObject> _listPowerUp;
	
	void Start()
	{
		CreatePoolPowerUp();
	}

	void CreatePoolPowerUp()
	{
		_powerUpContainer = ManagerResources.instance.powerUpRessourcesContainer;
		_listPowerUp = ManagerArray.instance.listPowerUp;
		ManagerPool.instance.CreatePool(_powerUpContainer, _listPowerUp, ammountPooledObject, _pooledParentObjectTagName);
	}
}