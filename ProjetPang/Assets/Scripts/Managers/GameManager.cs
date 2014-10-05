using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private bool _isInGame;
	public bool IsInGame()
	{
		return _isInGame;
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void OnEnable()
	{
		if(GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers") != null)
		{
			//this.GetComponent<ManagerArray>().OnGlobalEnable();
			this.GetComponent<ActiveStartObject>().OnGlobalEnable();
			this.GetComponent<ManagerPlatform>().OnGlobalEnable();
			//this.GetComponent<ManagerPool>().OnGlobalEnable();
			//this.GetComponent<ManagerPowerUp>().OnGlobalEnable();
			this.GetComponent<DetectBoundaries>().OnGlobalEnable();
			this.GetComponent<DisplayAmmo>().OnGlobalEnable();
			this.GetComponent<SetPositionBorderArrowType>().OnGlobalEnable();
			this.GetComponent<ManagerMenu>().OnGlobalEnable();
		}
	}

	// When the level change
	void OnLevelWasLoaded(int level) {

		// In game make a component that call all the others
		if(GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers") != null)
		{
			//this.GetComponent<ManagerArray>().OnGlobalEnable();
			this.GetComponent<ActiveStartObject>().OnGlobalEnable();
			this.GetComponent<ManagerPlatform>().OnGlobalEnable();
			//this.GetComponent<ManagerPool>().OnGlobalEnable();
			//this.GetComponent<ManagerPowerUp>().OnGlobalEnable();
			this.GetComponent<DetectBoundaries>().OnGlobalEnable();
			this.GetComponent<DisplayAmmo>().OnGlobalEnable();
			this.GetComponent<SetPositionBorderArrowType>().OnGlobalEnable();
			this.GetComponent<ManagerMenu>().OnGlobalEnable();
		}
	}
}
