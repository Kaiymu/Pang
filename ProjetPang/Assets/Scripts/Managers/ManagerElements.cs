using UnityEngine;
using System.Collections;

public class ManagerElements : MonoBehaviour{

	public enum Elements{noElement, Fire, Water, Earth, Wind};
	public Elements currentElement;

	private int _IDElement;

	public static ManagerElements instance;

	void Awake(){
		if(instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public int IDElement
	{
		get{return _IDElement;}
		set{if(value != null)
			_IDElement = value;}
	}
}
