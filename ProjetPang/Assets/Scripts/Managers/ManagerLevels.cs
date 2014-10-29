using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerLevels : SingleBehaviour<ManagerLevels> {

	public string ListLevelSceneName;

	private float currentLevel;
	private string _additiveLevelToLoad;
	private GameObject[] _retrieveAllLevels;
	private List<GameObject> _temporaryLevelsList = new List<GameObject>();

	private int _numberLevelAccessible;
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

	void OnLevelWasLoaded(int level) {
		//If the list levels is loaded, then we retrieve all the levels container.
		if (level == 1)
		{
			_retrieveAllLevels = GameObject.FindGameObjectsWithTag("ListLevels");
			HideNonAccessibleLevels();
		}
	}
	
	void HideNonAccessibleLevels()
	{
		foreach(GameObject child in _retrieveAllLevels)
		{
			for(int i = 0; i < child.gameObject.transform.childCount; i++)
			{
				_temporaryLevelsList.Add (child.gameObject.transform.GetChild(i).gameObject);
			}
		}

		for(int i = 0; i < ScoreXML.instance.memory.levels.Length; i++)
		{
			if(ScoreXML.instance.memory.levels[i] != 0)
			{
				_numberLevelAccessible = ScoreXML.instance.memory.levels[i];
			}
		}

		for(int i = _temporaryLevelsList.Count - 1; i > _numberLevelAccessible; i--)
		{
			_temporaryLevelsList[i].SetActive(false);
		}
	}
}
