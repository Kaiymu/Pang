using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the power up triple shoot gameobject
** If the player collides it, it gives him "_ammoTripleShoot" arrows, wich is defined by the game difficulty
************************************************************************************************/

public class PowerUpTripleShoot : MonoBehaviour {

	private int _ammoTripleShoot;

	public delegate void AmmoTripleShoot();

	void Start()
	{
		//_ammoTripleShoot = ManagerDifficulty.Instance.getAmmoTripleShoot();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		/*
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().setAmmoTripleShoot(_ammoTripleShoot);
			Destroy(this.gameObject);
		}
		*/
	}
}
