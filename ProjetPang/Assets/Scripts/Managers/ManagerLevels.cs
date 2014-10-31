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
	private int _level;
	// Use this for initialization

	public string additiveLevelToLoad
	{
		get{return _additiveLevelToLoad;}
		set{_additiveLevelToLoad = value;}
	}

	public int level
	{
		get{return _level;}
		set{_level = value;}
	}


	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void OnEnable(){
		LoadLevelAdditif.Loaded += LevelIsLoaded;
	}

	void GoToMainMenu(){
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}

	// Used in the main menu to go to the level list
	void GoToListLevels(){
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

	void OnLevelWasLoaded(int levelLoaded) {
		//If the list levels is loaded, then we get all the levels container.
		// I put the level in a private to access is asyncronosly in the LevelIsloaded
		level = levelLoaded;
		if (level == 1)
		{
			_retrieveAllLevels = GameObject.FindGameObjectsWithTag("ListLevels");
			CreateTemporyArrayLevelsGameobjects();
		}
	}

	void LevelIsLoaded()
	{
		if(_level == 3){
			_temporaryLevelsList.Clear();
			string o = GameObject.FindGameObjectWithTag("CurrentLevel").gameObject.name;
		}
	}

	// Loop throught the parents, to get all the childre, and put them in a array
	void CreateTemporyArrayLevelsGameobjects()
	{
		foreach(GameObject child in _retrieveAllLevels)
		{
			for(int i = 0; i < child.gameObject.transform.childCount; i++)
			{
				_temporaryLevelsList.Add (child.gameObject.transform.GetChild(i).gameObject);
			}
		}
		HideNonAccessibleLevels();
	}

	// If the player as already save a number of level, we retrieve this number to know how much levels we can display.
	void HideNonAccessibleLevels()
	{
		for(int i = 0; i < SaveScoreXML.instance.memory.levels.Length; i++)
		{
			if(SaveScoreXML.instance.memory.levels[i] != 0)
			{
				_numberLevelAccessible = SaveScoreXML.instance.memory.levels[i];
			}
		}

		Debug.Log (_numberLevelAccessible);
		for(int i = _temporaryLevelsList.Count - 1; i > _numberLevelAccessible -1 ; i--)
		{
			_temporaryLevelsList[i].SetActive(false);
		}
	}
}
