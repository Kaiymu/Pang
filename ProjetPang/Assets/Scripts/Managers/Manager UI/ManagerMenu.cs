﻿using UnityEngine;
using System.Collections;

public class ManagerMenu : MonoBehaviour {

	public GameObject _elementMenuToShow, _elementGameOverToShow, _elementWinToShow;

	private GameObject _player;

	//private GiveAllObjectsToManagers _giveAllObjectsToManagers;
	private ManagerInput _managerInput;

	public static ManagerMenu instance;

	private UISlider _numberSlider;
	private float _stamina = 0;
	
	public float stamina { 
		get { return _stamina; }
		set { _stamina = value;}
	}


	void Awake(){
		if(instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	
	void OnEnable(){
		LegacyOrbCollider.OnDestroy += UpdateStamina;
		ManagerEndGame.OnEndGame += EndGameMenu;
		ManagerEndGame.OnGameOver += GameOver;
	}

	void OnDisable(){
		LegacyOrbCollider.OnDestroy -= UpdateStamina;
		ManagerEndGame.OnEndGame -= EndGameMenu;
		ManagerEndGame.OnGameOver -= GameOver;
	}

	void UpdateStamina(float staminaValue) {
		_stamina += staminaValue;
	}

	void Update () {
		PausingGame();
	}

	void PausingGame()
	{
		if(ManagerInput.instance.isPausing()) {
			//Game is paused
			if(Time.timeScale != 0)
				DisplayElementToShow(_elementMenuToShow, true, 0);
			else 
				DisplayElementToShow(_elementMenuToShow, false, 1);
		}
	}

	// LE menu s'affiche bien. Plus qu'à faire en sorte que quand le joueur appuie sur le bouton, sa appelle la methode pour pouvoir mettre le oueru au prochain niveau.
	void EndGameMenu(){
		DisplayElementToShow(_elementMenuToShow, false, 0);
		DisplayElementToShow(_elementWinToShow, true, 0);
	}

	void GameOver(){
		DisplayElementToShow(_elementMenuToShow, false, 0);
		DisplayElementToShow(_elementGameOverToShow, true, 0);
	}

	void DisplayElementToShow(GameObject arrayToLoop, bool display, int pauseGame){
		Time.timeScale = pauseGame;
		for(int i = 0; i < arrayToLoop.transform.childCount; i++)
		{
			if(display && arrayToLoop.transform.GetChild(i).gameObject.activeInHierarchy)
				arrayToLoop.transform.GetChild(i).gameObject.SetActive(display);
			else
				arrayToLoop.transform.GetChild(i).gameObject.SetActive(display);
		}
	}
}
