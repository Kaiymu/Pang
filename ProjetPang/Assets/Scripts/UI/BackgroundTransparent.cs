using UnityEngine;
using System.Collections;

public class BackgroundTransparent : MonoBehaviour {

	// Make the black background become visible when the game in the victory / game over / menu state
	public Color startColorBackground;
	public Color endColorBackground;

	void Awake () {
		this.gameObject.renderer.material.color = startColorBackground;
	}


	void FadeInBackground()
	{
		this.gameObject.renderer.material.color = endColorBackground;
	}

	void UnfadeBackground()
	{
		this.gameObject.renderer.material.color = startColorBackground;
	}
}
