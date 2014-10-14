﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerOrb : SingleBehaviour<ManagerOrb> {

	// Gère la pool d'orb
	public float numberOrbs;
	public int ammountPooledObject;
	private string _pooledParentObjectTagName = "PooledOrb";

	// Mon tableau d'orb.
	private List<GameObject> _listOrb;
	private GameObject _orbContainer;
	private GameObject _orbsRessourcesContainer;

	private int _IDGroupOrb;

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
		_IDGroupOrb = currentOrb.GetComponent<GiveUniqueID>().IDGroup;
		
		if(currentOrb.GetComponent<GiveUniqueID>() == null || _IDGroupOrb == 3)
			return;
		else
		{
			for(int i = 0; i < numberOrbs; i++)
			{	
				for(int j = 0; j < _listOrb.Count; j += ammountPooledObject)
				{
					if(_listOrb[j].GetComponent<GiveUniqueID>().IDGroup == _IDGroupOrb)
					{
						int nextIDGroupOrb = (_IDGroupOrb + 1 ) * ammountPooledObject;
						GameObject nextOrbGroup = _listOrb[nextIDGroupOrb];
						if(i == 0)
							RecursifCreateBall(nextOrbGroup, nextIDGroupOrb, currentOrb, false);

						if(i == 1)
							RecursifCreateBall(nextOrbGroup, nextIDGroupOrb, currentOrb, true);
					}
				}
			}
		}
	}
	
	void RecursifCreateBall(GameObject orbToDisplay, int indexOrb, GameObject whereToInstantiate, bool negativeGo)
	{
		if(orbToDisplay.activeInHierarchy)
		{	
			indexOrb++;
			orbToDisplay = _listOrb[indexOrb];
			RecursifCreateBall(orbToDisplay, indexOrb, whereToInstantiate, negativeGo);
		}
		else
		{	
			if(negativeGo)
				orbToDisplay.GetComponent<OrbMovement>().startBouciness = -orbToDisplay.GetComponent<OrbMovement>().startBouciness;

			orbToDisplay.transform.position = whereToInstantiate.transform.position;
			orbToDisplay.transform.rotation = Quaternion.identity;
			orbToDisplay.SetActive(true);
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
