using UnityEngine;
using System.Collections;

public class GiveUniqueID : MonoBehaviour {

	public int _IDGroup;

	public int IDGroup
	{
		get{return _IDGroup;}
		set{if(value != null)
			_IDGroup = value;}
	}
}
