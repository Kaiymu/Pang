using UnityEngine;
using System.Collections;

public class ManagerScore : MonoBehaviour {
		
	private int _score;
	private int _combo;

	private bool _inCombo;

	public static ManagerScore instance;

	void Awake(){
		Debug.Log (instance);
		if(instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	
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

	public void Combo(int comboValue)
	{
		combo += comboValue;
		CancelInvoke();
		Invoke ("ResetCombo", 1);
	}

	void ResetCombo()
	{
		score = combo * 10;
		combo = 0;
	}
}
