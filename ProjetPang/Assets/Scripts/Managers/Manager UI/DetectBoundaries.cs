using UnityEngine;
using System.Collections;

public class DetectBoundaries : MonoBehaviour {
	
	private Vector3[] _positionsWall;

 	void OnEnable() {

		_positionsWall = new Vector3[4];
		_positionsWall[0] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height + 20f, Camera.main.nearClipPlane));
		_positionsWall[1] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
		_positionsWall[2] = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
		_positionsWall[3] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 30, Camera.main.nearClipPlane));

		for(int i = 0; i < this.transform.childCount -1 ; i++)
		{
			this.transform.GetChild(i).transform.position = _positionsWall[i];
		}

	}
}
