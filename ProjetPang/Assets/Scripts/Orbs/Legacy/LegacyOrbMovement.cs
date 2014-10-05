using UnityEngine;
using System.Collections;

public abstract class LegacyOrbMovement : MonoBehaviour {

	public float boucinessY;
	public float boucinessX;
	
	public float startBouciness;

	protected bool _canBounce = true;
	protected string _lastWallCollided;

	protected virtual void OnEnable () {
		rigidbody2D.AddForce(new Vector2(startBouciness, 0));
	}
	
	// Noter quel à été la dernière colision, et la refaire
	public virtual void MovementWall(string nameWall)
	{	
		if(nameWall == "2_LeftWall")
			rigidbody2D.AddForce(new Vector2(-boucinessX, 0));
		
		if(nameWall == "3_RightWall")
			rigidbody2D.AddForce(new Vector2(boucinessX, 0));
		
		if(nameWall == "1_BottomWall")
			rigidbody2D.AddForce(new Vector2(0, boucinessY));

	}
}
