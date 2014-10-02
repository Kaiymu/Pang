using UnityEngine;
using System.Collections;

public class OrbCollider : MonoBehaviour {

	private OrbTestMovement _orbTestMovement;

	void OnEnable()
	{
		_orbTestMovement = GetComponent<OrbTestMovement>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		WallCollision(col.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		ArrowCollision(col.gameObject.tag, col.gameObject);
	}

	void WallCollision(string wallName)
	{
		if(wallName == "2_LeftWall" || wallName ==  "3_RightWall" || wallName == "1_BottomWall")
			_orbTestMovement.MovementWall(wallName);
	}

	void ArrowCollision(string tag, GameObject collider)
	{
		if(tag == "ArrowNormal")
		{
			ManagerOrb.instance.CreateSmallerOrb(this.gameObject);
			this.gameObject.SetActive(false);
			collider.SetActive(false);
		}
	}
}
