using UnityEngine;
using System.Collections;

public class TimerBeginLevel : MonoBehaviour {

	public float timeLeft;
	private float coutdown = 0.02f;
	private bool _beginLevel = false;

	public GameObject menuToHide;
	public GameObject timerToDisplay;
	public GameObject timerToHide;

	private UILabel _infoLabel;

	void OnEnable() {
		Time.timeScale = 0;
		menuToHide.SetActive(false);
		timerToHide.SetActive(true);

		_infoLabel = timerToDisplay.GetComponent<UILabel>();
	
	}
	// Update is called once per frame
	void Update () {
		CountDownBeginLevel();
	}

	void CountDownBeginLevel() {
		if(!_beginLevel)
		{
			timeLeft -= coutdown;
			float timeLeftRounded = Mathf.Round(timeLeft);
			_infoLabel.text = "Game begin in : " + timeLeftRounded.ToString();
			if(timeLeft <= 0) {
				_beginLevel = true;

				menuToHide.SetActive(true);
				timerToHide.SetActive(false);

				Time.timeScale = 1;
			}
		}
	}
}
