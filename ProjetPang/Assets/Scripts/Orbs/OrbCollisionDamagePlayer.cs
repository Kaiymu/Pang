using UnityEngine;
using System.Collections;

/************************************************************************************************
* Only on the darkness orb
**  Make the cloud move up and down to make a wind effect
************************************************************************************************/

public class OrbCollisionDamagePlayer : MonoBehaviour {

	private int _damage;
	private OrbSize _currentSizeOrb;
	private ManagerDifficulty _managerDifficulty;

	void OnEnable()
	{
		_currentSizeOrb = this.GetComponent<OrbSize>();

		if(_currentSizeOrb.sizeOrb == OrbSize.Size.normalSize)
			_damage = ManagerDifficulty.instance.getDamageNormalOrb();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag == "Player")
		{
			col.transform.GetComponent<PlayerLife>().setLife(_damage);
			GameObject player = col.transform.gameObject;
		}
	}
}
