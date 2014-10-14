using UnityEngine;
using System.Collections;

/************************************************************************************************
* On every orb
**  Set the size of the orb when it's getting instantiate.
************************************************************************************************/

public class LegacyOrbSize : MonoBehaviour {

	public enum Size{bigSize, normalSize, midSize, smallSize};
	public Size sizeOrb;
	
	protected Vector3 _scaleOrb;
	
	protected virtual void OnEnable()
	{
		switch(sizeOrb)
		{
			case Size.bigSize:
				_scaleOrb = new Vector3(1.2f, 1.2f, 1.2f);
				break;
				
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
