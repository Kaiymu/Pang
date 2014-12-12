using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArrow : MonoBehaviour {

	public float ammountPooledObject;
	public static ManagerArrow instance;

	private string _pooledParentObjectTagName = "PooledArrow"; 
	private List<GameObject> _listArrow = new List<GameObject>();
	private GameObject _arrowContainer;

	void Awake(){
		if(instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
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