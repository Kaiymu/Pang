using UnityEngine;
using System.Collections;

public class EarthEffect : ActionElementalTap {

	protected OrbMovement _orbMovement;

	protected override void ElementalTap()
	{
		gameObject.renderer.material.color = Color.green;
		Destroy(GetComponent<EarthEffect>());
	}

}
