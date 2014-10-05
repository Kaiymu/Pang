using UnityEngine;
using System.Collections;

public abstract class LegacyOrbCollider : MonoBehaviour {

	protected OrbMovement _orbTestMovement;

	protected virtual void OnEnable()
	{
		_orbTestMovement = GetComponent<OrbMovement>();
	}
	
	protected virtual void OnCollisionEnter2D(Collision2D col)
	{
		WallCollision(col.gameObject.name);
	}
	
	protected virtual void OnTriggerEnter2D(Collider2D col)
	{
		ArrowCollision(col.gameObject.tag, col.gameObject);
	}
	
	protected virtual void WallCollision(string wallName)
	{
		if(wallName == "2_LeftWall" || wallName ==  "3_RightWall" || wallName == "1_BottomWall")
			_orbTestMovement.MovementWall(wallName);
	}
	
	protected virtual void ArrowCollision(string tag, GameObject collider)
	{
		if(tag == "ArrowNormal")
		{
			ManagerOrb.instance.CreateSmallerOrb(this.gameObject);
			this.gameObject.SetActive(false);
			collider.SetActive(false);
		}
	}
}
