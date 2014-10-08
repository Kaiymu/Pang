using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Main feature of the game;
 * Stop the time, calcul where the finger of the players his, to know which balls he has touched, and applies on effect on them.
 */

public class ManagerTouchTap : MonoBehaviour {

	public float radiusTap;

	private Vector3 _pos;
	private RaycastHit2D[] _hit;

	private int timeMoving = 0;
	private bool _pauseToTap = false;
	public int timeStopPause = 0;

	void Update () {

		PausingToTap();

		if(_pauseToTap)
			Touching2DElements();
		else
			ActionOnTapedObject();
	
	}

	// Stop the time for an amount of frame (Can't use time property because the time.scale is at 0).
	void PausingToTap()
	{
		if(ManagerInput.instance.stopingMovement() && !_pauseToTap){
			_pauseToTap = true;
			Time.timeScale = 0;
		}

		if(Time.timeScale == 0 && _pauseToTap)
		{
			timeMoving++;
			
			if(timeMoving > timeStopPause)
			{
				_pauseToTap = false;
				Time.timeScale = 1;
				timeMoving = 0;
			}
		}
	}

	// 2D Raycast to know wich balls he has hitted
	void Touching2DElements()
	{
		_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		_hit = Physics2D.CircleCastAll(_pos, radiusTap, Camera.main.transform.forward, 1);

		for(int i = 0; i < _hit.Length; i++)
		{
			if(_hit[i].collider.tag == "OrbIce" || _hit[i].collider.tag == "OrbDarkness"){
				if(!ManagerArray.instance.listOrbTaped.Contains(_hit[i].collider.gameObject))
				{
					_hit[i].collider.renderer.material.color = Color.red;
					ManagerArray.instance.listOrbTaped.Add(_hit[i].collider.gameObject);
				}
			}
		}
	}

	// Call the tap action method on each balls that was stored on the temporary List after the pause
	void ActionOnTapedObject()
	{
		if(ManagerArray.instance.listOrbTaped.Count != 0)
		{
			for(int i = 0; i < ManagerArray.instance.listOrbTaped.Count; i++)
			{
				if(ManagerArray.instance.listOrbTaped[i].activeInHierarchy)
					ManagerArray.instance.listOrbTaped[i].GetComponent<OrbTapAction>().TapAction();

			}
			ManagerArray.instance.listOrbTaped.Clear();
		}
	}
}
