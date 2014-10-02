using UnityEngine;
using System.Collections;

/************************************************************************************************
* On thep player
**  Getter / setter to know how much life the player has.
************************************************************************************************/

public class PlayerLife : MonoBehaviour {
	
	private int _life;

	void Awake()
	{
		_life = 100;
	}
	
	public int getLife()
	{
		return _life;
	}
	
	public void setLife(int life)
	{
		if(_life <= 0)
			_life = 0;
		else
			_life += life;
	}
}