using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {


	public Color fullLifeBar, nearFullLifeBar, nearEmptyBar, emptyBar;
	public GameObject player;

	private UISlider _UILife;
	private UISprite _UIColor;
	private PlayerLife _playerLife;

	// Life
	private float _getPlayerLife;
	private float _playerLifeDivided;
	
	void Start () {
		_UILife = this.gameObject.GetComponent<UISlider>();
		_UIColor = transform.GetChild(0).GetComponent<UISprite>();
		_playerLife = player.GetComponent<PlayerLife>();
	}

	void Update () {
		_getPlayerLife = _playerLife.getLife();
		_playerLifeDivided = _getPlayerLife / 100;
		_UILife.value = _playerLifeDivided;

		if(_getPlayerLife > 75)
			_UIColor.color = fullLifeBar;

		if(_getPlayerLife <= 75 && _getPlayerLife > 50)
			_UIColor.color = nearFullLifeBar;

		if(_getPlayerLife <= 50 && _getPlayerLife > 25)
			_UIColor.color = nearEmptyBar;

		if(_getPlayerLife <= 25)
			_UIColor.color = emptyBar;
			
		
	}
}
