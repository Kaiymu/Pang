using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/************************************************************************************************
 * On the arrow GameObject
**  Put back the orb object in the object pool, and instantiate new object in function of the game difficulty.
************************************************************************************************/

public class ArrowDestroyOrbs : MonoBehaviour {
	
	private int _numberOrbs;
	private int _chanceSpawn;

	private GameObject _randomPowerUp;
	private List<GameObject> _listPowerUp;
	private List<GameObject> _arrayOrb;
	private ManagerDifficulty _managerDifficulty;

	private ManagerArray _managerArray;
	private ManagerProbabilitySpawn _managerProbabilitySpawn;

	void OnEnable()
	{	
		//_arrayOrb = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerPool>().getOrb();
		_managerArray = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerArray>();
		_managerProbabilitySpawn = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerProbabilitySpawn>();
		//_listPowerUp = _managerArray.getPowerUp();
	
		_managerDifficulty = ManagerDifficulty.Instance;

		_chanceSpawn = _managerDifficulty.getBonusChanceSpawn();
		_numberOrbs  = _managerDifficulty.getNumberOrb();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		/*
		if(col.transform.tag == "OrbDarkness")
		{
			instantiateOrbs(_numberOrbs, col.gameObject);

			if(_managerProbabilitySpawn.spawnGameobjects(_chanceSpawn))
			{
				_randomPowerUp = _listPowerUp[Random.Range(0, _listPowerUp.Count)];
				GameObject o = (GameObject) Instantiate(_randomPowerUp, this.transform.position, Quaternion.identity);
				o.GetComponent<PowerUpSetSpeed>().speed = 1;
			}
			
			//_managerArray.removeOrbFromArray(col.gameObject);
			col.gameObject.SetActive(false);
			this.gameObject.SetActive(false);
		}
		else if(col.transform.tag == "OrbIce")
		{
			//_managerArray.removeOrbFromArray(col.gameObject);
			col.gameObject.SetActive(false);
			this.gameObject.SetActive(false);
		}
		*/
	}
	


	void instantiateOrbs(int number, GameObject col)
	{
		OrbSize.Size sizeOrb = col.GetComponent<OrbSize>().sizeOrb;

		// If the ball is really small or if it's a ice ball, we destroy it.
		if(sizeOrb == OrbSize.Size.smallSize)
			return;
		else
		{
			for(int i = 0; i < number; i++)
			{
				for(int j = 0; j < _arrayOrb.Count; j++)
				{
					GameObject randomOrb = _arrayOrb[Random.Range(0, _arrayOrb.Count)];

					if(!randomOrb.activeInHierarchy)
					{
						if(sizeOrb == OrbSize.Size.normalSize) // If it's normal, we instantiate a mid ball.
						{
							randomOrb.transform.position = this.transform.position;
							randomOrb.transform.rotation = Quaternion.identity;
							randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.midSize;
							randomOrb.SetActive(true);
							break;
						}	
						
						if(sizeOrb == OrbSize.Size.midSize) // If it's mid, we instantiate a small ball.
						{
							randomOrb.transform.position = this.transform.position;
							randomOrb.transform.rotation = Quaternion.identity;
							randomOrb.GetComponent<OrbSize>().sizeOrb = OrbSize.Size.smallSize;
							randomOrb.SetActive(true);
							break;
						}
					}
				}
			}
		}
	}
}
