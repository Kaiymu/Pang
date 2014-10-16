using UnityEngine;
using System.Collections;

public class LoadLevelAdditif : MonoBehaviour {
	
	private string nameLevelToDownLoad;

	void Awake()
	{
		nameLevelToDownLoad = ManagerLevels.instance.additiveLevelToLoad;
	}
	
	IEnumerator Start() {
		Debug.Log ("toto");
		AsyncOperation asyncManagersScene = Application.LoadLevelAdditiveAsync("ManagersScene");
		AsyncOperation asyncUIScene = Application.LoadLevelAdditiveAsync("AdditifLevelUI");
		AsyncOperation asyncGameScene = Application.LoadLevelAdditiveAsync(nameLevelToDownLoad);

		yield return asyncManagersScene;
		yield return asyncUIScene;
		yield return asyncGameScene;
		Debug.Log("Loading complete");
	}
}
