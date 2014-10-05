using UnityEngine;
using System.Collections;

public class ManagerResources : SingleBehaviour<ManagerResources> {

	private GameObject _orbRessourcesContainer;
	private GameObject _arrowRessourcesContainer;

	void Awake()
	{
		orbRessourceContainer = Resources.Load ("Prefabs/Orbs/OrbsRessourcesContainer") as GameObject;
		arrowRessourcesContainer = Resources.Load ("Prefabs/Arrow/ArrowContainer") as GameObject;
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
		
}
