using UnityEngine;
using System.Collections;

public class LoadMainMenu : MonoBehaviour {

	void Awake()
	{
		Application.LoadLevel("MainMenu");
	}
}
