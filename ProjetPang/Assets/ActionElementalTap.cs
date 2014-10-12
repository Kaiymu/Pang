using UnityEngine;
using System.Collections;

public abstract class ActionElementalTap : MonoBehaviour {

	protected OrbCollider _orbCollider;

	protected virtual void OnEnable()
	{
		_orbCollider = this.GetComponent<OrbCollider>();
		ElementalTap();
	}

	protected abstract void ElementalTap();                            
}
		
