using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the power up attract gameobject
**  If the player collides it, it gives him "_ammoAttractShoot" arrow, wich is defined by the game difficulty
************************************************************************************************/

public class PowerUpAttract : MonoBehaviour {

	private int _ammoAttractShoot;

	void Start()
	{
		_ammoAttractShoot = ManagerDifficulty.Instance.getAmmoAttractShoot();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		/*
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerShoot>().setAmmoAttractShoot(_ammoAttractShoot);
			Destroy(this.gameObject);
		}
		*/
	}
}