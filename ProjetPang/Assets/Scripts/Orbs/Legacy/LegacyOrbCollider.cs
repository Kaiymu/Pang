using UnityEngine;
using System.Collections;

public abstract class LegacyOrbCollider : MonoBehaviour {
	
	protected OrbMovement _orbMovement;
	public bool canInvokeSmallerOrb = true;
	public Color colorBase;

	public delegate void OnDestroyOrb(float staminaValue);
	public static event OnDestroyOrb OnDestroy;


	protected virtual void OnEnable()
	{
		_orbMovement = GetComponent<OrbMovement>();
		colorBase = this.renderer.material.color;
	}

	protected virtual void OnDisable()
	{
		this.renderer.material.color = this.colorBase;
		this.GetComponent<OrbScore>().NormalEffect();
		this.canInvokeSmallerOrb = true;
		this.rigidbody2D.gravityScale = 0.4f;
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
			_orbMovement.MovementWall(wallName);
	}
	
	protected virtual void ArrowCollision(string tag, GameObject collided)
	{
		if(tag == "ArrowNormal")
			DestroyOrb(this.gameObject, collided);
	}

	public virtual void DestroyOrb(GameObject toDestroy, GameObject collided)
	{
		if(canInvokeSmallerOrb)
			ManagerOrb.instance.CreateSmallerOrb(toDestroy);

		RemoveComponent(toDestroy);
		IncreseStamina(toDestroy);
		GetScore(toDestroy);
		toDestroy.SetActive(false);

		if(collided != null)
			collided.SetActive(false);

		ManagerPowerUp.instance.PutRandomPowerUpInGame(toDestroy);
	}

	private void RemoveComponent(GameObject toRemove)
	{
		if(toRemove.GetComponent<FireEffect>() != null)
			Destroy(toRemove.GetComponent<FireEffect>());
		if(toRemove.GetComponent<WaterEffect>() != null)
			Destroy(toRemove.GetComponent<WaterEffect>());
		if(toRemove.GetComponent<EarthEffect>() != null)
			Destroy(toRemove.GetComponent<EarthEffect>());
		if(toRemove.GetComponent<WindEffect>() != null)
			Destroy(toRemove.GetComponent<WindEffect>());
	}

	private void GetScore(GameObject toScore)
	{
		ManagerScore.instance.score = toScore.GetComponent<OrbScore>().score;
		ManagerScore.instance.Combo(toScore.GetComponent<OrbScore>().combo);
	}

	private void IncreseStamina(GameObject sizeOrb) {
		OrbSize.Size sizeCurrentOrb = sizeOrb.GetComponent<OrbSize>().sizeOrb;
		float staminaValue = 0f;

		switch(sizeCurrentOrb)
		{
			case OrbSize.Size.bigSize :
				staminaValue = 0.15f;
			break;

			case OrbSize.Size.midSize :
				staminaValue = 0.12f;
			break;

			case OrbSize.Size.normalSize :
				staminaValue = 0.07f;
			break;

			case OrbSize.Size.smallSize :
				staminaValue = 0.05f;
			break;
		}

		OnDestroy(staminaValue);
	}
}
