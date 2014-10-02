using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArrow : MonoBehaviour {

	public float ammountPooledObject;

	private List<GameObject> _listArrow;
	private GameObject _arrowContainer;
	
	void Start()
	{	
		CreatePoolArrow();
	}

	void CreatePoolArrow()
	{
		_arrowContainer = ManagerResources.instance.arrowRessourcesContainer;
		_listArrow = ManagerArray.instance.listArrow;
		ManagerPool.instance.CreatePool(_arrowContainer, _listArrow, ammountPooledObject);
	}
}