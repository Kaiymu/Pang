using UnityEngine;
using System.Collections;

public class DontDestroyOnload : MonoBehaviour {

	public GameObject gameManager;

	void Awake () {
		DontDestroyOnLoad(gameManager.transform.gameObject);
	}

}
