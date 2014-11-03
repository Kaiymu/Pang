using UnityEngine;
using System.Collections;

public abstract class DestroyOnWall : MonoBehaviour {

	protected virtual void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Wall")
			this.gameObject.SetActive(false);
	}
}
