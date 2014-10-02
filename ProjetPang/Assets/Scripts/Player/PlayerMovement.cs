using UnityEngine;
using System.Collections;

/************************************************************************************************
* On the player
**  A moving component, and animator component, from left to right.
************************************************************************************************/

public class PlayerMovement : MonoBehaviour {
			
	public float speed;

	private Animator anim;

	// Velocity of the layer
	private Vector2 _velocity;	

	// To know where the player is walking
	private bool _walkRight;
	private bool _walkLeft;

	// 0 left, 1 right, 2 idle. To know in wich side he stopped.
	private int _dirWalk;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		Movement();
	}

	void Movement()
	{	
		_velocity = new Vector2(speed, 0);

		if(ManagerInput.instance.isMovingLeft())
		{
			this.transform.Translate(-_velocity * Time.deltaTime);
			_walkLeft = true;
			_dirWalk = 0;
			anim.SetInteger("dirWalk", 2);
		}
		else
			_walkLeft = false;

		if(ManagerInput.instance.isMovingRight())
		{
			this.transform.Translate(_velocity * Time.deltaTime);
			_walkRight = true;
			_dirWalk = 1;
			anim.SetInteger("dirWalk", 2);
		}
		else
			_walkRight = false;


		anim.SetBool("walk_left", _walkLeft);
		anim.SetBool("walk_right", _walkRight);

		if(!_walkLeft && !_walkRight)
		{		
			if(_dirWalk == 0)
				anim.SetInteger("dirWalk", 0);

			if(_dirWalk == 1)
				anim.SetInteger("dirWalk", 1);
		}
	}
}