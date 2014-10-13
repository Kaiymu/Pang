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
		Destroy(GetComponent<WindEffect>());
	}

}
