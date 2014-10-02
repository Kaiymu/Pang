using UnityEngine;
using System.Collections;

/************************************************************************************************
* Only on the ice Orb
**  Make the player slows and blink in a blue color.
************************************************************************************************/

public class OrbSlowPlayer : MonoBehaviour {

	public float slowSpeedPlayer = 0.1f;
	public float numberColorBlink;
	public float speedColorBlink;
	
	void OnCollisionEnter2D(Collision2D col)
	{

	}
}
