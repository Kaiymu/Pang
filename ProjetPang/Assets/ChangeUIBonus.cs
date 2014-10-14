using UnityEngine;
using System.Collections;

public class ChangeUIBonus : MonoBehaviour {

	private int ancientIDElement;

	void Update()
	{
		ChangeSpriteUI();
	}


	// Search into the sprite array, the ID of the current element to display the right element UI.
	void ChangeSpriteUI()
	{
		if(ManagerElements.instance.IDElement != ancientIDElement)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = ManagerArray.instance.listSpritePowerUp[ManagerElements.instance.IDElement];
			ancientIDElement = ManagerElements.instance.IDElement;
		}

	}
}
