using UnityEngine;
using System.Collections;

public class FireEffect : ActionElementalTap {

	protected override void ElementalTap()
	{
		_orbCollider.DestroyOrb(this.gameObject, null);
		gameObject.renderer.material.color = _colorBase;;
		Destroy(GetComponent<FireEffect>());
	}
	
	protected override void ResetNormal()
	{
		
	}
}
