using UnityEngine;
using System.Collections;

public class WaterEffect : ActionElementalTap {

	private GameObject _player;

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void ElementalTap()
	{
		this.renderer.material.color = Color.blue;
		this.GetComponent<OrbScore>().WaterEffect();
		Invoke ("ResetNormal", 5);
	}

	protected override void ResetNormal()
	{
		this.renderer.material.color = _colorBase;
		this.GetComponent<OrbScore>().NormalEffect();
		Destroy(GetComponent<WaterEffect>());
	}
}
