using UnityEngine;
using System.Collections;

public class TimeShootedBar : MonoBehaviour {


	public GameObject player;

	private UISlider _UITimeShooted;
	private PlayerShoot _lastShot;

	void Start () {
		_UITimeShooted = this.gameObject.GetComponent<UISlider>();
		_lastShot      = player.GetComponent<PlayerShoot>();
	}

	void Update()
	{
		/*
		_UITimeShooted.value = _lastShot.getLastShot();
		*/
	}
}
