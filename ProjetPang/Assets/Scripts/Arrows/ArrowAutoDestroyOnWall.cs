using UnityEngine;
using System.Collections;

/************************************************************************************************
*On the arrow GameObject
** Put back the arrow in the object pool when it collide with a wall
************************************************************************************************/

public class ArrowAutoDestroyOnWall : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Wall")
			this.gameObject.SetActive(false);
	}
}
