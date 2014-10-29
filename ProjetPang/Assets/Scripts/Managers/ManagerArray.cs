using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerArray : SingleBehaviour<ManagerArray> {

	private List<GameObject> _listOrb = new List<GameObject>();
	private List<GameObject> _listOrbInGame = new List<GameObject>();

	private List<GameObject> _listArrow = new List<GameObject>();
	private List<GameObject> _listOrbTaped = new List<GameObject>();
	private List<GameObject> _listPowersUp = new List<GameObject>();
	private List<Sprite> _listSpritePowerUp = new List<Sprite>();

	public List<GameObject> listOrb
	{
		get {return _listOrb;} 
		set {if(value != null)
				_listOrb = value;
		}
	}

	public List<GameObject> listOrbInGame
	{
		get {return _listOrbInGame;} 
		set {if(value != null)
			_listOrbInGame = value;
		}
	}

	public List<GameObject> listArrow
	{
		get {return _listArrow;} 
		set {if(value != null)
				_listArrow = value;
		}
	}

	public List<GameObject> listOrbTaped
	{
		get {return _listOrbTaped;} 
		set {
			if(value != null)
			_listOrbTaped = value;
		}
	}

	public List<GameObject> listPowerUp
	{
		get {return _listPowersUp;} 
		set {
			if(value != null)
				_listPowersUp = value;
		}
	}

	public List<Sprite> listSpritePowerUp
	{
		get {return _listSpritePowerUp;} 
		set {
			if(value != null)
				_listSpritePowerUp = value;
		}
	}

	public int countActiveInHiearchy(List<GameObject> listToCount)
	{
		int numberActiveHiearchy = 0;
		for(int i = 0; i < listToCount.Count; i++)
		{
			if(listToCount[i].activeInHierarchy)
				numberActiveHiearchy++;
		}
		return numberActiveHiearchy;
	}
}
