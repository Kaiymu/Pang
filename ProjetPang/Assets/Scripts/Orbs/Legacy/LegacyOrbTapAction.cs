using UnityEngine;
using System.Collections;

public abstract class LegacyOrbTapAction : MonoBehaviour {

	public virtual void TapAction()
	{
		switch (ManagerElements.instance.currentElement)
		{
			case ManagerElements.Elements.Fire:
				FireEffect();
			break;

			case ManagerElements.Elements.Water:
				WaterEffect();
			break;

			case ManagerElements.Elements.Earth:
				EarthEffect();
			break;

			case ManagerElements.Elements.Wind:
				WindEffect();
			break;
		}
	}

	protected virtual void FireEffect()
	{
		gameObject.renderer.material.color = Color.red;
	}

	protected virtual void WaterEffect()
	{
		gameObject.renderer.material.color = Color.blue;
	}

	protected virtual void EarthEffect()
	{
		gameObject.renderer.material.color = Color.green;
	}

	protected virtual void WindEffect()
	{
		gameObject.renderer.material.color = Color.black;
	}
}
