using UnityEngine;
using System.Collections;

public class DetectBoundaries : MonoBehaviour {

	public GameObject _giveAllObjectsToManagers;
	private Vector3[] _positionsWall;

 	void OnEnable() {

		_positionsWall = new Vector3[4];
		_positionsWall[0] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height + 20f, Camera.main.nearClipPlane));
		_positionsWall[1] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
		_positionsWall[2] = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
		_positionsWall[3] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));

		//_giveAllObjectsToManagers = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>().walls;

		// If a bug, check the order of the walls in the array

		for(int i = 0; i < _giveAllObjectsToManagers.transform.childCount; i++)
		{
			Debug.Log ("toto");
			_giveAllObjectsToManagers.transform.GetChild(i).transform.position = _positionsWall[i];
		}

	}
}
