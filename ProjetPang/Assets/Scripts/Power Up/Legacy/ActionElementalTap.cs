using UnityEngine;
using System.Collections;

public abstract class ActionElementalTap : MonoBehaviour {

	protected OrbCollider _orbCollider;
	public Color _colorBase;

	protected virtual void OnEnable()
	{
		_orbCollider = this.GetComponent<OrbCollider>();
		_colorBase = this.GetComponent<LegacyOrbCollider>().colorBase;
		ElementalTap();
	}

	protected abstract void ElementalTap();       
	protected abstract void ResetNormal();
}
		
