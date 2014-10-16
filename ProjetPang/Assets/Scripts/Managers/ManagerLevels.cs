using UnityEngine;
using System.Collections;

public class ManagerLevels : SingleBehaviour<ManagerLevels> {

	public string ListLevelSceneName;

	private float currentLevel;
	private string _additiveLevelToLoad;
	// Use this for initialization

	public string additiveLevelToLoad
	{
		get{return _additiveLevelToLoad;}
		set{_additiveLevelToLoad = value;}
	}

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	void GoToMainMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}

	// Used in the main menu to go to the level list
	void GoToListLevels()
	{
		Time.timeScale = 1;
		Application.LoadLevel(ListLevelSceneName);
	}

	// Called in the list level, when the players push a buttons to go to the level
	void GoToLevel(GameObject gameObjectLevel)
	{
		Time.timeScale = 1;
		_additiveLevelToLoad = gameObjectLevel.name;
		Application.LoadLevel("AdditifRegroupLevels");
	}

	void QuitGame()
	{
		Application.Quit();
	}

}
