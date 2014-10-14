using UnityEngine;
using System.Collections;

public class ManagerElements : SingleBehaviour<ManagerElements> {

	public enum Elements{noElement, Fire, Water, Earth, Wind};
	public Elements currentElement;

	private int _IDElement;
	
	public int IDElement
	{
		get{return _IDElement;}
		set{if(value != null)
			_IDElement = value;}
	}

}
