using UnityEngine;
using System.Collections;

public class ManagerResources : SingleBehaviour<ManagerResources> {

	private GameObject _orbRessourcesContainer;
	private GameObject _arrowRessourcesContainer;
	private GameObject _powerUpRessourcesContainer;
	private GameObject _XMLScoreResources;

	void Awake()
	{
		orbRessourceContainer = Resources.Load ("Prefabs/Orbs/OrbsRessourcesContainer") as GameObject;
		arrowRessourcesContainer = Resources.Load ("Prefabs/Arrow/ArrowContainer") as GameObject;
		powerUpRessourcesContainer = Resources.Load ("Prefabs/PowerUp/Base/PowerUp_Base") as GameObject;
		_XMLScoreResources = Resources.Load ("Save2") as GameObject;
	}

	void Start()
	{
		Debug.Log (_XMLScoreResources);
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

	public GameObject XMLScoreResources
	{
		get{return _XMLScoreResources;}
		set{_XMLScoreResources = value;}
	}

}
