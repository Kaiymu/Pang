using UnityEngine;
using System.Collections;

/************************************************************************************************
* On every orb
**  Set the size of the orb when it's getting instantiate.
************************************************************************************************/

public class OrbSize : MonoBehaviour {

	public enum Size{normalSize, midSize, smallSize};
	public Size sizeOrb;

	private Vector3 _scaleOrb;

	void OnEnable()
	{
		switch(sizeOrb)
		{
			case Size.normalSize:
				_scaleOrb = new Vector3(1f, 1f, 1f);
			break;

			case Size.midSize : 
				_scaleOrb = new Vector3(0.75f, 0.75f, 0.75f);
			break;

			case Size.smallSize :
				_scaleOrb = new Vector3(0.40f, 0.40f, 0.40f);
			break;
		}

		this.transform.localScale = _scaleOrb;
	}
	
}
