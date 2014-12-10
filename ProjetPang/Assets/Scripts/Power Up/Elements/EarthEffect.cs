using UnityEngine;
using System.Collections;

public class EarthEffect : ActionElementalTap {

	private OrbMovement _orbMovement;

	protected override void ElementalTap()
	{
		gameObject.renderer.material.color = Color.green;
		this.GetComponent<OrbCollider>().canInvokeSmallerOrb = false;
		Invoke ("ResetNormal", 5);
	}

	protected override void ResetNormal()
	{
		this.GetComponent<OrbCollider>().canInvokeSmallerOrb = true;
		this.renderer.material.color = _colorBase;
		Destroy(GetComponent<EarthEffect>());
	}

}
