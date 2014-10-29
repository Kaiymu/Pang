using UnityEngine;
using System.Collections;

public class LoadLevelAdditif : MonoBehaviour {
	
	private string nameLevelToDownLoad;
	private int _level;
	private bool _isLoaded;

	public delegate void LevelFullLoaded();
	public static event LevelFullLoaded Loaded;
	
	void Awake()
	{
		nameLevelToDownLoad = ManagerLevels.instance.additiveLevelToLoad;
	}
	
	IEnumerator Start() {
		AsyncOperation asyncManagersScene = Application.LoadLevelAdditiveAsync("ManagersScene");
		AsyncOperation asyncUIScene = Application.LoadLevelAdditiveAsync("AdditifLevelUI");
		AsyncOperation asyncGameScene = Application.LoadLevelAdditiveAsync(nameLevelToDownLoad);

		yield return asyncManagersScene;
		yield return asyncUIScene;
		yield return asyncGameScene;
		Debug.Log("Loading complete");

		Loaded();
	}
}
