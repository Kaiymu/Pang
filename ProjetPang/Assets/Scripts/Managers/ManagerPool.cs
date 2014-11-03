using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPool : SingleBehaviour<ManagerPool> {

	public int countActiveInHiearchy(List<GameObject> listToCount)
	{
		int numberActiveHiearchy = 0;
		for(int i = 0; i < listToCount.Count; i++)
		{
			if(listToCount[i].activeInHierarchy)
				numberActiveHiearchy++;
		}
		return numberActiveHiearchy;
	}

	/* Takes a parent object, loops into it, retrieve all the children, give them a "group ID" and then put it into a parent pooled object.
	 */
	public void CreatePool(GameObject objectToPool, List<GameObject> arrayObjectPool, float amountPooled, string tagParentObject)
	{	
		// To get the object where the pooled object will be put. 
		GameObject parentObject = GameObject.FindGameObjectWithTag(tagParentObject);

		for(int i = 0; i < objectToPool.transform.childCount; i++)
		{
			for(int j = 0; j < amountPooled; j++)
			{
				GameObject o = Instantiate(objectToPool.transform.GetChild(i).gameObject) as GameObject;

				if(parentObject != null)
					o.transform.parent = parentObject.transform;
			
				o.AddComponent<GiveUniqueID>().IDGroup = i;
				arrayObjectPool.Add(o);
			}
		}
	}
}
