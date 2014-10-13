using UnityEngine;
using System.Collections;

public class FireEffect : ActionElementalTap {

	protected override void ElementalTap()
	{
		_orbCollider.DestroyOrb(this.gameObject, null);
		Destroy(GetComponent<FireEffect>());
	}

}
