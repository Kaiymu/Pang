using UnityEngine;
using System.Collections;

public class WaterEffect : ActionElementalTap {

	private GameObject _player;

	protected override void OnEnable()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
		base.OnEnable();
	}

	protected override void ElementalTap()
	{
		_player.GetComponent<PlayerMovement>().speed += 1;
		Destroy(GetComponent<WaterEffect>());
	}
}
