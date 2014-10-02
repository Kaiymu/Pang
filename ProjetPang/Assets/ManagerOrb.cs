using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerOrb : SingleBehaviour<ManagerOrb> {
	
	// Créer les orbes en cas de destruction
	// Gère la pool d'orb

	// Mon tableau d'orb.
	private List<GameObject> _listOrb;
	private GameObject _orbContainer;
	private GameObject _orbsRessourcesContainer;

	public float ammountPooledObject;

	public float _numberOrbs;

	// Get the size of the orb wich was destroyed
	private OrbSize.Size sizeOrb;

	// Retrieve a random orb from the orbContainer
	private GameObject randomOrb;

	void Start()
	{
		CreatePoolOrb();
		ActiveOrb();
	}

	// Retrieve and activate the starting orbs on the current map.
	void ActiveOrb()
	{
		_orbContainer = GameObject.FindGameObjectWithTag("OrbContainer");
		
		if(_orbContainer != null)
		{
			for(int i = 0; i < _orbContainer.transform.childCount; i++)
				_orbContainer.transform.GetChild(i).gameObject.SetActive(true);
		}
	}

	// Create the pull object for the orbs.
	void CreatePoolOrb()
	{	
		_orbContainer = ManagerResources.instance.orbRessourceContainer;
		_listOrb = ManagerArray.instance.listOrb;
		ManagerPool.instance.CreatePool(_orbContainer, _listOrb, ammountPooledObject);
	}

	public void CreateSmallerOrb(GameObject currentOrb)
	{
		sizeOrb = currentOrb.GetComponent<OrbSize>().sizeOrb;

		if(sizeOrb == OrbSize.Size.smallSize)
			return;
		else
			for(int i = 0; i < _numberOrbs; i++)
			{
				for(int j = 0; j < _listOrb.Count; j++)
				{
					if(!_listOrb[j].activeInHierarchy && _listOrb[j].gameObject.tag != "OrbDarkness")
					{
						int randomNumber = Random.Range(0, _listOrb.Count);
						randomOrb = _listOrb[randomNumber];

						if(sizeOrb == OrbSize.Size.normalSize)
						{
							randomOrb.transform.position = currentOrb.transform.position;
							randomOrb.transform.rotation = Quaternion.identity;
							randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
							randomOrb.SetActive(true);
							break;
						}
					}
				}
			}
	}

	/*
	void instantiateOrbs(int number, GameObject col)
	{
		OrbSize.Size sizeOrb = col.GetComponent<OrbSize>().sizeOrb;
		
		// If the ball is really small or if it's a ice ball, we destroy it.
		if(sizeOrb == OrbSize.Size.smallSize)
			return;
		else
		{
			for(int i = 0; i < number; i++)
			{
				for(int j = 0; j < _arrayOrb.Count; j++)
				{
					GameObject randomOrb = _arrayOrb[Random.Range(0, _arrayOrb.Count)];
					
					if(!randomOrb.activeInHierarchy)
					{
						if(sizeOrb == OrbSize.Size.normalSize) // If it's normal, we instantiate a mid ball.
						{
							randomOrb.transform.position = this.transform.position;
							randomOrb.transform.rotation = Quaternion.identity;
							randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
							randomOrb.SetActive(true);
							break;
						}	
						
						if(sizeOrb == OrbSize.Size.midSize) // If it's mid, we instantiate a small ball.
						{
							randomOrb.transform.position = this.transform.position;
							randomOrb.transform.rotation = Quaternion.identity;
							randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
							randomOrb.SetActive(true);
							break;
						}
					}
				}
			}
		}
	}
*/
}
