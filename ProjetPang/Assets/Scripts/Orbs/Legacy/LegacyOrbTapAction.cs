using UnityEngine;
using System.Collections;

public abstract class LegacyOrbTapAction : MonoBehaviour {

	public virtual void TapAction()
	{
		gameObject.renderer.material.color = Color.blue;
	}
}
