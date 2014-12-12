using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Main feature of the game;
 * Stop the time, calcul where the finger of the players his, to know which balls he has touched, and applies on effect on them.
 */

public class ManagerTouchTap : MonoBehaviour {

	public float radiusTap;
	public int timeStopPause = 0;
	
	private Vector3 _pos;
	private RaycastHit2D[] _hit;

	private int timeMoving = 0;
	private bool _pauseToTap = false;
	private List<GameObject> _listOrbTaped = new List<GameObject>();
	
	public List<GameObject> listOrbTaped
	{
		get {return _listOrbTaped;} 
		set {
			if(value != null)
				_listOrbTaped = value;
		}
	}

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
			if(_hit[i].collider.tag == "OrbIce" || _hit[i].collider.tag == "OrbMalusTaped"){
				if(!listOrbTaped.Contains(_hit[i].collider.gameObject))
				{
					_hit[i].collider.renderer.material.color = ChangeSpriteColor();
					listOrbTaped.Add(_hit[i].collider.gameObject);
				}
			}
		}
	}

	// Call the tap action method on each balls that was stored on the temporary List after the pause
	void ActionOnTapedObject()
	{
		if(listOrbTaped.Count != 0)
		{
			for(int i = 0; i < listOrbTaped.Count; i++)
			{
				if(listOrbTaped[i].activeInHierarchy)
					if(listOrbTaped[i].tag == "OrbMalusTaped")
						ManagerOrb.instance.CreateSmallerOrb(listOrbTaped[i]);
					else
						ManagerOrb.instance.AffectOrb(listOrbTaped[i]);
			}
			listOrbTaped.Clear();
		}
	}

	Color ChangeSpriteColor()
	{
		switch(ManagerElements.instance.currentElement)
		{
			case ManagerElements.Elements.Fire: 
				return Color.red;
			break;

			case ManagerElements.Elements.Water:
				return Color.blue;
			break;

			case ManagerElements.Elements.Earth:
				return Color.green;
			break;

			case ManagerElements.Elements.Wind:
				return Color.cyan;
			break;
		}
		return Color.red;
	}
}
