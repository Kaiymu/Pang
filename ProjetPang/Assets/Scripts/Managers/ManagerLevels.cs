﻿using UnityEngine;
using System.Collections;

public class ManagerLevels : SingleBehaviour<ManagerLevels> {

	public string ListLevelSceneName;

	private float currentLevel;
	// Use this for initialization

	void Update()
	{
		GoToMainMenu();
	}

	void GoToMainMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}

	// Used in the main menu to go to the level list
	void GoToListLevels()
	{
		Debug.Log("toto");
		Time.timeScale = 1;
		Application.LoadLevel(ListLevelSceneName);
	}

	// Called in the list level, when the players push a buttons to go to the level
	void GoToLevel(GameObject gameObjectLevel)
	{
		Time.timeScale = 1;
		Application.LoadLevel(gameObjectLevel.name);
	}
}
