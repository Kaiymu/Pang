using UnityEngine;
using System.Collections;

/************************************************************************************************
* On every orb
**  Make the orb adding itself to the array, to know how much orb i have on the game.
************************************************************************************************/

public class OrbArray : MonoBehaviour {

	private ManagerArray _managerArray;

	void OnEnable()
	{
		//_managerArray = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerArray>();
		//_managerArray.addOrbToArray(this.gameObject);
	}
}
