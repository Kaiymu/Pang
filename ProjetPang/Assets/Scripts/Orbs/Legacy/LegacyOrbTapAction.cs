using UnityEngine;
using System.Collections;

public abstract class LegacyOrbTapAction : MonoBehaviour {

	public bool malusTaped;

	protected OrbCollider _orbCollider;
	protected LegacyOrbMovement _orbMovement;
	protected float _startTime; 
	protected bool _isTaped;
	protected GameObject _player;

	protected virtual void OnEnable()
	{
		_orbCollider = this.GetComponent<OrbCollider>();
		_orbMovement = this.GetComponent<OrbMovement>();
		_player      = GameObject.FindGameObjectWithTag("Player");
	}

	public virtual void TapAction()
	{
		/*
		if(malusTaped) 
			MalusEffect();
		else 
		{
			switch (ManagerElements.instance.currentElement)
			{
				case ManagerElements.Elements.Fire:
					FireEffect();
				break;

				case ManagerElements.Elements.Water:
					_isTaped = true;
					WaterEffect();
				break;

				case ManagerElements.Elements.Earth:
					_isTaped = true;
					EarthEffect();
				break;

				case ManagerElements.Elements.Wind:
					_isTaped = true;
					WindEffect();
				break;
			}
		}
		*/
	}

	protected virtual void Update()
	{
		if(_isTaped)
			_startTime += Time.deltaTime;
	}

	protected virtual void FireEffect()
	{
		//_orbCollider.DestroyOrb(this.gameObject, null);
		//gameObject.AddComponent<FireEffect>();
	}

	protected virtual void WaterEffect()
	{ 
		_player.GetComponent<PlayerMovement>().speed += 1;
	}

	protected virtual void EarthEffect()
	{
		gameObject.renderer.material.color = Color.green;
	}

	protected virtual void WindEffect()
	{
		_orbMovement.FloattingOrbs(this.gameObject);
	}

	protected virtual void MalusEffect()
	{
		_player.GetComponent<PlayerMovement>().speed -= 0.2f;
	}
}
