using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPowerUp : SingleBehaviour<ManagerPowerUp> {

	public float speed;
	public int ammountPooledObject;
	public int chanceToSpawn;

	private string _pooledParentObjectTagName = "PooledPowerUp";
	private GameObject _powerUpContainer;

	private List<GameObject> _listPowerUp = new List<GameObject>();
	private List<Sprite> _listSpritePowerUp = new List<Sprite>();
	
	private float _randomNumber;

	public List<GameObject> listPowerUp
	{
		get {return _listPowerUp;} 
		set {
			if(value != null)
				_listPowerUp = value;
		}
	}
	
	public List<Sprite> listSpritePowerUp
	{
		get {return _listSpritePowerUp;} 
		set {
			if(value != null)
				_listSpritePowerUp = value;
		}
	}

	void Start()
	{
		CreatePoolPowerUp();
		CreateArraySprite();
	}

	/* Put the power up into their own pool object. 
	 */
	void CreatePoolPowerUp()
	{
		_powerUpContainer = ManagerResources.instance.powerUpRessourcesContainer;
		ManagerPool.instance.CreatePool(_powerUpContainer, _listPowerUp, ammountPooledObject, _pooledParentObjectTagName);
	}

	/* Create a array of sprite, to render the good sprites in the UI. 
	 * Put in the right orders the sprite, then automaticly gives the right sprite to the UI.
	 */
	void CreateArraySprite()
	{
		for(int i = 0; i < _powerUpContainer.transform.childCount; i++)
		{
			Sprite s = _powerUpContainer.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
			listSpritePowerUp.Add(s);
		}
	}

	public void PutRandomPowerUpInGame(GameObject _whereToInstantiate)
	{
		if(_whereToInstantiate != null)
		{
			_randomNumber = Random.Range(0, 100);

			if(_randomNumber < chanceToSpawn)
			{
				float s = 0;
				_randomNumber = Random.Range(0f, 1f);

				for(int i = 0; i < listPowerUp.Count; i += ammountPooledObject)
				{
					s += listPowerUp[i].GetComponent<PowerUpChanceSpawn>().chanceToSpawn;

					if(_randomNumber < s)
					{
						GameObject _randomPowerUp = listPowerUp[i];
						if(!_randomPowerUp.activeInHierarchy)
						{
							_randomPowerUp.transform.position = _whereToInstantiate.transform.position;
							_randomPowerUp.GetComponent<PowerUpMovement>().speed = speed;
							_randomPowerUp.SetActive(true);
							break;
						}
					}
				}
			}
		}
	}
}