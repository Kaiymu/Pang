using UnityEngine;
using System.Collections;
using System.Linq;

public class SortGameObjectsChildrenByName : SingleBehaviour<SortGameObjectsChildrenByName> {

	/* Take a gameobejct with children in parameters, and sort them by their name */
	public GameObject[] sortArrayFromName(GameObject childArrayToSort)
	{
		GameObject[] _arrayToSort = new GameObject[childArrayToSort.transform.childCount];
		GameObject o;

		for (int i = 0; i < childArrayToSort.transform.childCount; i++)
		{
			o = childArrayToSort.transform.GetChild(i).gameObject;
			_arrayToSort[i] = o;
		}

		_arrayToSort = _arrayToSort.OrderBy(go => go.name).ToArray();
		
		return _arrayToSort;
	}
}
