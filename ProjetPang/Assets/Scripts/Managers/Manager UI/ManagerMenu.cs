using UnityEngine;
using System.Collections;

public class ManagerMenu : MonoBehaviour {

	public GameObject _elementMenuToShow, _elementGameOverToShow, _elementWinToShow;

	private GameObject _player;

	// If the player can die or not.
	public bool debug;

	//private GiveAllObjectsToManagers _giveAllObjectsToManagers;
	private ManagerInput _managerInput;

	void Awake()
	{
		_managerInput = ManagerInput.instance;
	}

	void OnEnable()
	{
		_managerInput = ManagerInput.instance;
	}

	void Update () 
	{
		PausingGame();
		GoingMainMenu();
	}

	void PausingGame()
	{
		if(_managerInput.isPausing()){
			//Game is paused
			if(Time.timeScale != 0){
				Time.timeScale = 0;
				for(int i = 0; i < _elementMenuToShow.transform.childCount; i++)
				{
					_elementMenuToShow.transform.GetChild(i).gameObject.SetActive(true);
				}
			}
			else {
				Time.timeScale = 1; 	// Game is playing
				for(int i = 0; i < _elementMenuToShow.transform.childCount; i++)
				{
					_elementMenuToShow.transform.GetChild(i).gameObject.SetActive(false);	
				}
			}
		}
	}

	void GoingMainMenu()
	{
		if(_managerInput.goingBackMainMenu())
			Application.LoadLevel("MainMenu");
	}
}
