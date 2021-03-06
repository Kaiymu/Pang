﻿using UnityEngine;
using System.Collections;

public class ManagerResources : MonoBehaviour {

	private GameObject _orbRessourcesContainer;
	private GameObject _arrowRessourcesContainer;
	private GameObject _powerUpRessourcesContainer;
	public static ManagerResources instance;

	void Awake()
	{
		if(instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}

		orbRessourceContainer = Resources.Load ("Prefabs/Orbs/OrbsRessourcesContainer") as GameObject;
		arrowRessourcesContainer = Resources.Load ("Prefabs/Arrow/ArrowContainer") as GameObject;
		powerUpRessourcesContainer = Resources.Load ("Prefabs/PowerUp/Base/PowerUp_Base") as GameObject;
	}

	public GameObject orbRessourceContainer
	{
		get{return _orbRessourcesContainer;}
		set{_orbRessourcesContainer = value;}
	}

	public GameObject arrowRessourcesContainer
	{
		get{ return _arrowRessourcesContainer;}
		set{_arrowRessourcesContainer = value;}
	}

	public GameObject powerUpRessourcesContainer
	{
		get{ return _powerUpRessourcesContainer;}
		set{_powerUpRessourcesContainer = value;}
	}
}
