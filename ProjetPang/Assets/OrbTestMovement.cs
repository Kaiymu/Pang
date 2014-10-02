using UnityEngine;
using System.Collections;

public class OrbTestMovement : MonoBehaviour {

	public float boucinessY;
	public float boucinessX;

	void OnEnable () {
		rigidbody2D.AddForce(new Vector2(boucinessX, 0));
	}
	
	public void MovementWall(string nameWall)
	{
		if(nameWall == "2_LeftWall")
			rigidbody2D.AddForce(new Vector2(-boucinessX, 0));

		if(nameWall == "3_RightWall")
			rigidbody2D.AddForce(new Vector2(boucinessX, 0));

		if(nameWall == "1_BottomWall")
			rigidbody2D.AddForce(new Vector2(0, boucinessY));
	}
}
