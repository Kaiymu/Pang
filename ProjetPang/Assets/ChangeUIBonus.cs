using UnityEngine;
using System.Collections;

public class ChangeUIBonus : MonoBehaviour {

	public Sprite[] bonusUITexture;

	private SpriteRenderer _spriteRenderer;
	private ManagerElements.Elements test;

	void Awake()
	{
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		ChangeSpriteUI();
	}

	void ChangeSpriteUI()
	{
		if(ManagerElements.instance.currentElement != test)
		{
			switch (ManagerElements.instance.currentElement)
			{
				case ManagerElements.Elements.noElement:
					_spriteRenderer.sprite = bonusUITexture[4];
				break;
				case ManagerElements.Elements.Fire:
					_spriteRenderer.sprite = bonusUITexture[0];
					break;
				case ManagerElements.Elements.Water:
					_spriteRenderer.sprite = bonusUITexture[1];
					break;
				case ManagerElements.Elements.Earth:
					_spriteRenderer.sprite = bonusUITexture[2];
					break;
				case ManagerElements.Elements.Wind:
					_spriteRenderer.sprite = bonusUITexture[3];
					break;
			}
			gameObject.GetComponent<SpriteRenderer>().sprite = _spriteRenderer.sprite;
		}

		test = ManagerElements.instance.currentElement;
	}
}
