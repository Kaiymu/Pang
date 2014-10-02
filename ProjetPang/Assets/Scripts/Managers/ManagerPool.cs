using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : SingleBehaviour<ManagerPool> {
	
	public void CreatePool(GameObject objectToPool, List<GameObject> arrayObjectPool, float amountPooled)
	{	
		for(int i = 0; i < objectToPool.transform.childCount; i++)
		{
			for(int j = 0; j < amountPooled; j++)
			{
				GameObject o = Instantiate(objectToPool.transform.GetChild(i).gameObject) as GameObject;
				arrayObjectPool.Add(o);
			}
		}
	}
}
