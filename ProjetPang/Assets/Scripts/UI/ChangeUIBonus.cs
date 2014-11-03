using UnityEngine;
using System.Collections;

public class ChangeUIBonus : MonoBehaviour {

	private SpriteRenderer _spriteUI;
	private int ancientIDElement;

	void Start()
	{
		_spriteUI = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		ChangeSpriteUI();
	}
	
	// Search into the sprite array, the ID of the current element to display the right element UI.
	void ChangeSpriteUI()
	{
		if(ManagerElements.instance.IDElement != ancientIDElement)
		{
			_spriteUI.sprite = ManagerPowerUp.instance.listSpritePowerUp[ManagerElements.instance.IDElement];
			ancientIDElement = ManagerElements.instance.IDElement;
		}
	}
}
