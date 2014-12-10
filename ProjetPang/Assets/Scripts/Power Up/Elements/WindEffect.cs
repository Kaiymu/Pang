using UnityEngine;
using System.Collections;

public class WindEffect : ActionElementalTap {

	protected OrbMovement _orbMovement;

	protected override void OnEnable()
	{
		_orbMovement = this.GetComponent<OrbMovement>();
		base.OnEnable();
	}

	protected override void ElementalTap()
	{
		_orbMovement.FloattingOrbs(this.gameObject);
		Invoke ("ResetNormal", 5);
	}
	
	protected override void ResetNormal()
	{
		this.renderer.material.color = _colorBase;
		this.rigidbody2D.gravityScale = 0.4f;
		Destroy(GetComponent<WindEffect>());
	}
}
