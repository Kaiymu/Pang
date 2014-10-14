using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerOrb : SingleBehaviour<ManagerOrb> {

	// Gère la pool d'orb
	public float numberOrbs;
	public float ammountPooledObject;
	private string _pooledParentObjectTagName = "PooledOrb";

	// Mon tableau d'orb.
	private List<GameObject> _listOrb;
	private GameObject _orbContainer;
	private GameObject _orbsRessourcesContainer;
	
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
		ManagerPool.instance.CreatePool(_orbContainer, _listOrb, ammountPooledObject, _pooledParentObjectTagName);
	}

	public void CreateSmallerOrb(GameObject currentOrb)
	{
		sizeOrb = currentOrb.GetComponent<OrbSize>().sizeOrb;

		if(sizeOrb == OrbSize.Size.smallSize)
			return;
		else
			for(int i = 0; i < numberOrbs; i++)
			{
				for(int j = 0; j < _listOrb.Count; j++)
				{
					if(!_listOrb[j].activeInHierarchy && _listOrb[j].gameObject.tag != "OrbDarkness")
					{
						int randomNumber = Random.Range(0, _listOrb.Count);
						randomOrb = _listOrb[randomNumber];

						randomOrb.transform.position = currentOrb.transform.position;
						randomOrb.transform.rotation = Quaternion.identity;

						if(i == 0)
						{
							if(sizeOrb == OrbSize.Size.bigSize)
							{
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.normalSize;
								randomOrb.GetComponent<OrbMovement>().bouncinessY = 190;
								randomOrb.GetComponent<OrbMovement>().bouncinessX = 110;
								randomOrb.GetComponent<OrbMovement>().startBouciness = 110;

								randomOrb.SetActive(true);
								break;
							}

							if(sizeOrb == OrbSize.Size.normalSize)
							{
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
								randomOrb.GetComponent<OrbMovement>().bouncinessY = 160;
								randomOrb.GetComponent<OrbMovement>().bouncinessX = 90; 
								randomOrb.GetComponent<OrbMovement>().startBouciness = 90;
								randomOrb.SetActive(true);
								break;
							}

							if(sizeOrb == OrbSize.Size.midSize)
							{
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
								randomOrb.GetComponent<OrbMovement>().bouncinessY = 135;
								randomOrb.GetComponent<OrbMovement>().bouncinessX = 75;
								randomOrb.GetComponent<OrbMovement>().startBouciness = 75;
								randomOrb.SetActive(true);
								break;
							}
						}
						if(i == 1)
						{
							if(sizeOrb == OrbSize.Size.bigSize)
							{
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.normalSize;
								randomOrb.GetComponent<OrbMovement>().bouncinessY = 190;
								randomOrb.GetComponent<OrbMovement>().bouncinessX = 110; 
								randomOrb.GetComponent<OrbMovement>().startBouciness = -110;
								randomOrb.SetActive(true);
								break;
							}

							if(sizeOrb == OrbSize.Size.normalSize)
							{
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
								randomOrb.GetComponent<OrbMovement>().bouncinessY = 160;
								randomOrb.GetComponent<OrbMovement>().bouncinessX = 90; 
								randomOrb.GetComponent<OrbMovement>().startBouciness = -90; 
								randomOrb.SetActive(true);
								break;
							}

							if(sizeOrb == OrbSize.Size.midSize)
							{
								randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
								randomOrb.GetComponent<OrbMovement>().bouncinessY = 135;
								randomOrb.GetComponent<OrbMovement>().bouncinessX = 75; 
								randomOrb.GetComponent<OrbMovement>().startBouciness = -75; 
								randomOrb.SetActive(true);
								break;
							}
						}
					}
				}
			}
	}

	public void AffectOrb(GameObject orbToAffect)
	{
		switch (ManagerElements.instance.currentElement)
		{
			case ManagerElements.Elements.Fire:
				orbToAffect.AddComponent<FireEffect>();
			break;
			case ManagerElements.Elements.Water:
				orbToAffect.AddComponent<WaterEffect>();
			break;
			case ManagerElements.Elements.Earth:
				orbToAffect.AddComponent<EarthEffect>();
			break;
			case ManagerElements.Elements.Wind:
				orbToAffect.AddComponent<WindEffect>();
			break;
		}
	}

}
