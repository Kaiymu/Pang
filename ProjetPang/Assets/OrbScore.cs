using UnityEngine;
using System.Collections;

public class OrbScore : MonoBehaviour {

	private int _score = 10;
	private int _combo = 1;

	public int score
	{
		get{return _score;}
		set{if(value != 0)
			_score = value;}
	}

	public int combo
	{
		get{return _combo;}
		set{if(value != 0)
			_combo = value;}
	}

	public void NormalEffect()
	{
		_score = 10;
		_combo = 1;
	}
	public void WaterEffect()
	{
		Debug.Log ("toto");
		_score = 20;
		_combo = 2;
	}
}
