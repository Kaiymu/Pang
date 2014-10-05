using UnityEngine;
using System.Collections;

/* Main feature of the game;
 * Stop the time, calcul where the finger of the players his, to know which balls he has touched, and applies on effect on them.
 */

public class ManagerTouchTap : MonoBehaviour {

	private Vector3 _pos;
	private RaycastHit2D _hit;

	private int timeMoving = 0;
	private bool _pauseToTap;
	public int timeStopPause = 0;

	void Update () {

		PausingToTap();

		if(_pauseToTap)
			Touching2DElements();

		ActionOnTapedObject();
	
	}

	// Stop the time for an amount of frame (Can't use time property because the time.scale is at 0).
	void PausingToTap()
	{
		if(ManagerInput.instance.stopingMovement()){
			_pauseToTap = true;
			Time.timeScale = 0;
		}

		if(Time.timeScale == 0)
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
		_hit = Physics2D.Raycast(_pos, Vector2.zero);
		
		if (_hit != null && _hit.collider != null) {
			if(_hit.collider.tag == "OrbIce" || _hit.collider.tag == "OrbDarkness"){
				if(!ManagerArray.instance.listOrbTaped.Contains(_hit.collider.gameObject))
				{
					_hit.collider.renderer.material.color = Color.red;
					ManagerArray.instance.listOrbTaped.Add(_hit.collider.gameObject);
				}
			}
		}
	}

	// Call the tap action method on each balls that was stored on the temporary List after the pause
	void ActionOnTapedObject()
	{
		if(!_pauseToTap && ManagerArray.instance.listOrbTaped.Count != 0)
		{
			for(int i = 0; i < ManagerArray.instance.listOrbTaped.Count; i++)
			{
				ManagerArray.instance.listOrbTaped[i].GetComponent<OrbTapAction>().TapAction();
			}

			ManagerArray.instance.listOrbTaped.Clear();
		}
	}
}
