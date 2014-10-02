using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : SingleBehaviour<ManagerArray> {

	private List<GameObject> _listOrb = new List<GameObject>();
	private List<GameObject> _listArrow = new List<GameObject>();
	
	public List<GameObject> listOrb
	{
		get {return _listOrb;} 
		set {if(value != null)
				_listOrb = value;
		}
	}

	public List<GameObject> listArrow
	{
		get {return _listArrow;} 
		set {
			if(value != null)
				_listArrow = value;
		}
	}

}
