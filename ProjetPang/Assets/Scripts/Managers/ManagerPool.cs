using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : SingleBehaviour<ManagerPool> {

	private GameObject parentObject;

	public void CreatePool(GameObject objectToPool, List<GameObject> arrayObjectPool, float amountPooled, string tagParentObject)
	{	
		// To get the object where the pooled object will be put. 
		parentObject = GameObject.FindGameObjectWithTag(tagParentObject);

		for(int i = 0; i < objectToPool.transform.childCount; i++)
		{
			for(int j = 0; j < amountPooled; j++)
			{
				GameObject o = Instantiate(objectToPool.transform.GetChild(i).gameObject) as GameObject;

				if(parentObject != null)
					o.transform.parent = parentObject.transform;

				arrayObjectPool.Add(o);
			}
		}
	}
}
