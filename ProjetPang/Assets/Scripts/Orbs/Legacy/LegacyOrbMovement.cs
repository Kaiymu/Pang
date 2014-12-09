using UnityEngine;
using System.Collections;

public abstract class LegacyOrbMovement : MonoBehaviour {

	public float bouncinessY;
	public float bouncinessX;
	
	public float startBouciness;

	protected bool _canBounce = true;

	protected virtual void OnEnable () {
		rigidbody2D.AddForce(new Vector2(startBouciness, 0));
	}

	public virtual void MovementWall(string nameWall)
	{	
		if(nameWall == "2_LeftWall")
			rigidbody2D.AddForce(new Vector2(-bouncinessX, 0));
		
		if(nameWall == "3_RightWall")
			rigidbody2D.AddForce(new Vector2(bouncinessX, 0));
		
		if(nameWall == "1_BottomWall")
			rigidbody2D.AddForce(new Vector2(0, bouncinessY));
	}

	public virtual void FloattingOrbs(GameObject orbToFloat)
	{
		orbToFloat.rigidbody2D.gravityScale = 0.3f;
		StartCoroutine(BasicComportement(orbToFloat));
	}

	public virtual IEnumerator BasicComportement(GameObject orb)
	{
		yield return new WaitForSeconds(5f);
		orb.rigidbody2D.gravityScale = 0.4f;
	}
}
