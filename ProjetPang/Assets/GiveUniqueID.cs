using UnityEngine;
using System.Collections;

public class GiveUniqueID : MonoBehaviour {

	private int _ID;

	public int ID
	{
		get{return _ID;}
		set{if(value != null)
			_ID = value;}
	}
}
