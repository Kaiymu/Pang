using UnityEngine;
using System.Collections;

public class ManagerScore : SingleBehaviour<ManagerScore> {
		
	private int _score;

	public int score 
	{
		get{return _score;}
		set{if(value > 0)
			_score += value;}
	}
}
