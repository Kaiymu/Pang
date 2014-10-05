using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPowerUp : SingleBehaviour<ManagerPowerUp> {

	public int ammountPooledObject;
	public float speed;

	private string _pooledParentObjectTagName = "PooledPowerUp";
	private GameObject _powerUpContainer;
	private List<GameObject> _listPowerUp;

	private int _randomNumber;
	private GameObject _randomPowerUp;
	
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

	public void PutRandomPowerUpInGame(GameObject whereToInstantiate)
	{
		if(whereToInstantiate != null)
		{
			_randomNumber = Random.Range(0, ManagerArray.instance.listPowerUp.Count);
			_randomPowerUp = ManagerArray.instance.listPowerUp[_randomNumber];

			if(!_randomPowerUp.activeInHierarchy)
			{
				_randomPowerUp.transform.position = whereToInstantiate.transform.position;
				_randomPowerUp.GetComponent<PowerUpMovement>().speed = speed;
				_randomPowerUp.SetActive(true);
			}
		}
	}
}