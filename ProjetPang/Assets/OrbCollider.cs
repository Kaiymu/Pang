using UnityEngine;
using System.Collections;

public class OrbCollider : LegacyOrbCollider {

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnCollisionEnter2D(Collision2D col)
	{
		base.OnCollisionEnter2D(col);
	}

	protected override void OnTriggerEnter2D(Collider2D col)
	{
		base.OnTriggerEnter2D(col);
	}

	protected override void WallCollision(string wallName)
	{
		base.WallCollision(wallName);
	}

	protected override void ArrowCollision(string tag, GameObject collider)
	{
		base.ArrowCollision(tag, collider);
	}
}
