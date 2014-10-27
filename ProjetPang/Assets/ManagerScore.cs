using UnityEngine;
using System.Collections;

public class ManagerScore : SingleBehaviour<ManagerScore> {
		
	private int _score;
	private int _combo;

	private bool _inCombo;
	
	public int score 
	{
		get{return _score;}
		set{if(value > 0)
			_score += value;}
	}

	public int combo 
	{
		get{return _combo;}
		set{_combo = value;}
	}

	public void Combo()
	{
		combo++;
		CancelInvoke();
		Invoke ("Test", 1);
	}

	void Test()
	{
		score = combo * 10;
		combo = 0;
	}
}
