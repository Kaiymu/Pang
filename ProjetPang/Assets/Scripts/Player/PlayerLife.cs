using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	public bool playerDead = false;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "OrbIce" || col.tag == "OrbMalusTaped")
		{
			playerDead = true;
		}
	}
}