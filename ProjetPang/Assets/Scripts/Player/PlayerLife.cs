using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	public bool playerDead = false;

    void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag == "OrbIce" || col.gameObject.tag == "OrbMalusTaped")
		{
			playerDead = true;
		}
	}
}