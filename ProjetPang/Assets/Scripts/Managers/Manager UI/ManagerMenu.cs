using UnityEngine;
using System.Collections;

public class ManagerMenu : MonoBehaviour {

	public GameObject _elementMenuToShow, _elementGameOverToShow, _elementWinToShow;

	private GameObject _player;

	//private GiveAllObjectsToManagers _giveAllObjectsToManagers;
	private ManagerInput _managerInput;
	
	void OnEnable(){
		ManagerEndGame.OnEndGame += EndGameMenu;
	}

	void Update () {
		Debug.Log (Time.timeScale);
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

	void DisplayElementToShow(GameObject arrayToLoop, bool display, int pauseGame){

		Time.timeScale = pauseGame;
		for(int i = 0; i < arrayToLoop.transform.childCount; i++)
		{
			arrayToLoop.transform.GetChild(i).gameObject.SetActive(display);	
		}
	}
}
