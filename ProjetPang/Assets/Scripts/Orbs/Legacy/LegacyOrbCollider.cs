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
	
	protected virtual void ArrowCollision(string tag, GameObject collided)
	{
		if(tag == "ArrowNormal")
			DestroyOrb(this.gameObject, collided);
	}

	public virtual void DestroyOrb(GameObject toDestroy, GameObject collided)
	{
		ManagerOrb.instance.CreateSmallerOrb(toDestroy);
		ManagerPowerUp.instance.PutRandomPowerUpInGame(toDestroy);
		toDestroy.SetActive(false);

		if(collided != null)
			collided.SetActive(false);
	}
}
