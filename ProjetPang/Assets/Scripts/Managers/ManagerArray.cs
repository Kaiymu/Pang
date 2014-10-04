using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : SingleBehaviour<ManagerArray> {

	private List<GameObject> _listOrb = new List<GameObject>();
	private List<GameObject> _listArrow = new List<GameObject>();

	private int numberActiveHiearchy;
	
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

	public int countActiveInHiearchy(List<GameObject> listToCount)
	{
		numberActiveHiearchy = 0;
		for(int i = 0; i < listToCount.Count; i++)
		{
			if(listToCount[i].activeInHierarchy)
				numberActiveHiearchy++;
		}
		return numberActiveHiearchy;
	}
}
