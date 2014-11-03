using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArrow : SingleBehaviour<ManagerArrow> {

	public float ammountPooledObject;

	private string _pooledParentObjectTagName = "PooledArrow"; 
	private List<GameObject> _listArrow = new List<GameObject>();
	private GameObject _arrowContainer;

	public List<GameObject> listArrow
	{
		get {return _listArrow;} 
		set {if(value != null)
			_listArrow = value;
		}
	}

	void Start()
	{	
		CreatePoolArrow();
	}

	void CreatePoolArrow()
	{
		_arrowContainer = ManagerResources.instance.arrowRessourcesContainer;
		ManagerPool.instance.CreatePool(_arrowContainer, _listArrow, ammountPooledObject, _pooledParentObjectTagName);
	}
}